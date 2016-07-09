// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Common;
using Mosa.Compiler.Framework;
using Mosa.Compiler.Linker;
using System;
using System.Diagnostics;

namespace Mosa.Platform.x86
{
	/// <summary>
	/// An x86 machine code emitter.
	/// </summary>
	public sealed class MachineCodeEmitter : BaseCodeEmitter
	{
		#region Code Generation

		/// <summary>
		/// Calls the specified target.
		/// </summary>
		/// <param name="symbolOperand">The symbol operand.</param>
		public void EmitCallSite(Operand symbolOperand)
		{
			linker.Link(
				LinkType.RelativeOffset,
				PatchType.I4,
				MethodName,
				SectionKind.Text,
				(int)codeStream.Position,
				-4,
				symbolOperand.Name,
				SectionKind.Text,
				0
			);

			codeStream.WriteZeroBytes(4);
		}

		/// <summary>
		/// Emits relative branch code.
		/// </summary>
		/// <param name="code">The branch instruction code.</param>
		/// <param name="dest">The destination label.</param>
		public void EmitRelativeBranch(byte[] code, int dest)
		{
			codeStream.Write(code, 0, code.Length);
			EmitRelativeBranchTarget(dest);
		}

		/// <summary>
		/// Emits the specified op code.
		/// </summary>
		/// <param name="opCode">The op code.</param>
		/// <param name="dest">The dest.</param>
		public void Emit(OpCode opCode, Operand dest)
		{
			// Write the opcode
			codeStream.Write(opCode.Code, 0, opCode.Code.Length);

			byte? sib = null, modRM = null;
			Operand displacement = null;

			// Write the mod R/M byte
			modRM = CalculateModRM(opCode.RegField, dest, null, out sib, out displacement);
			if (modRM != null)
			{
				codeStream.WriteByte(modRM.Value);
				if (sib.HasValue)
					codeStream.WriteByte(sib.Value);
			}

			// Add displacement to the code
			if (displacement != null)
				WriteDisplacement(displacement);
		}

		/// <summary>
		/// Emits the given code.
		/// </summary>
		/// <param name="opCode">The op code.</param>
		/// <param name="dest">The destination operand.</param>
		/// <param name="src">The source operand.</param>
		public void Emit(OpCode opCode, Operand dest, Operand src)
		{
			// Write the opcode
			codeStream.Write(opCode.Code, 0, opCode.Code.Length);

			if (dest == null && src == null)
				return;

			byte? sib = null, modRM = null;
			Operand displacement = null;

			// Write the mod R/M byte
			modRM = CalculateModRM(opCode.RegField, dest, src, out sib, out displacement);
			if (modRM != null)
			{
				codeStream.WriteByte(modRM.Value);
				if (sib.HasValue)
					codeStream.WriteByte(sib.Value);
			}

			// Add displacement to the code
			if (displacement != null)
				WriteDisplacement(displacement);

			// Add immediate bytes
			if (dest.IsConstant)
				WriteImmediate(dest);
			else if (dest.IsSymbol)
				WriteDisplacement(dest);
			else if (src != null && src.IsConstant)
				WriteImmediate(src);
			else if (src != null && src.IsSymbol)
				WriteDisplacement(src);
		}

		/// <summary>
		/// Emits the given code.
		/// </summary>
		/// <param name="opCode">The op code.</param>
		/// <param name="dest">The dest.</param>
		/// <param name="src">The source.</param>
		/// <param name="third">The third.</param>
		public void Emit(OpCode opCode, Operand dest, Operand src, Operand third)
		{
			// Write the opcode
			codeStream.Write(opCode.Code, 0, opCode.Code.Length);

			if (dest == null && src == null)
				return;

			byte? sib = null, modRM = null;
			Operand displacement = null;

			// Write the mod R/M byte
			modRM = CalculateModRM(opCode.RegField, dest, src, out sib, out displacement);
			if (modRM != null)
			{
				codeStream.WriteByte(modRM.Value);
				if (sib.HasValue)
					codeStream.WriteByte(sib.Value);
			}

			// Add displacement to the code
			if (displacement != null)
				WriteDisplacement(displacement);

			// Add immediate bytes
			if (third != null && third.IsConstant)
				WriteImmediate(third);
		}

		/// <summary>
		/// Emits the displacement operand.
		/// </summary>
		/// <param name="displacement">The displacement operand.</param>
		private void WriteDisplacement(Operand displacement)
		{
			if (displacement.IsLabel)
			{
				// FIXME! remove assertion
				Debug.Assert(displacement.Offset == 0);

				linker.Link(LinkType.AbsoluteAddress, PatchType.I4, MethodName, SectionKind.Text, (int)codeStream.Position, 0, displacement.Name, SectionKind.ROData, 0);
				codeStream.WriteZeroBytes(4);
			}
			else if (displacement.IsField)
			{
				var section = displacement.Field.Data != null ? SectionKind.ROData : SectionKind.BSS;

				linker.Link(LinkType.AbsoluteAddress, PatchType.I4, MethodName, SectionKind.Text, (int)codeStream.Position, 0, displacement.Field.FullName, section, (int)displacement.Offset);
				codeStream.WriteZeroBytes(4);
			}
			else if (displacement.IsSymbol)
			{
				// FIXME! remove assertion
				Debug.Assert(displacement.Offset == 0);

				var section = (displacement.Method != null) ? SectionKind.Text : SectionKind.ROData;

				var symbol = linker.GetSymbol(displacement.Name, section);

				if (symbol == null)
				{
					symbol = linker.FindSymbol(displacement.Name);
				}

				linker.Link(LinkType.AbsoluteAddress, PatchType.I4, MethodName, SectionKind.Text, (int)codeStream.Position, 0, symbol, 0);
				codeStream.WriteZeroBytes(4);
			}
			else
			{
				codeStream.Write((int)displacement.Offset, Endianness.Little);
			}
		}

		/// <summary>
		/// Emits an immediate operand.
		/// </summary>
		/// <param name="op">The immediate operand to emit.</param>
		private void WriteImmediate(Operand op)
		{
			if (op.IsCPURegister)
				return; // nothing to do.

			if (op.IsStackLocal)
			{
				codeStream.Write((int)op.Offset, Endianness.Little);
				return;
			}

			if (!op.IsConstant)
			{
				throw new InvalidCompilerException();
			}

			if (op.IsI1)
				codeStream.WriteByte((byte)op.ConstantSignedInteger);
			else if (op.IsU1 || op.IsBoolean)
				codeStream.WriteByte(Convert.ToByte(op.ConstantUnsignedInteger));
			else if (op.IsU2 || op.IsChar)
				codeStream.Write(Convert.ToUInt16(op.ConstantUnsignedInteger), Endianness.Little);
			else if (op.IsI2)
				codeStream.Write(Convert.ToInt16(op.ConstantSignedInteger), Endianness.Little);
			else if (op.IsI4 || op.IsI)
				codeStream.Write(Convert.ToInt32(op.ConstantSignedInteger), Endianness.Little);
			else if (op.IsU4 || op.IsPointer || op.IsU || !op.IsValueType)
				codeStream.Write(Convert.ToUInt32(op.ConstantUnsignedInteger), Endianness.Little);
			else
				throw new InvalidCompilerException();
		}

		/// <summary>
		/// Emits the relative branch target.
		/// </summary>
		/// <param name="label">The label.</param>
		private void EmitRelativeBranchTarget(int label)
		{
			// The relative offset of the label
			int relOffset = 0;

			// The position in the code stream of the label
			int position;

			// Did we see the label?
			if (TryGetLabel(label, out position))
			{
				// Yes, calculate the relative offset
				relOffset = position - ((int)codeStream.Position + 4);
			}
			else
			{
				// Forward jump, we can't resolve yet - store a patch
				AddPatch(label, (int)codeStream.Position);
			}

			// Emit the relative jump offset (zero if we don't know it yet!)
			codeStream.Write(relOffset, Endianness.Little);
		}

		public override void ResolvePatches()
		{
			// Save the current position
			long currentPosition = codeStream.Position;

			foreach (var p in patches)
			{
				int labelPosition;
				if (!TryGetLabel(p.Label, out labelPosition))
				{
					throw new ArgumentException("Missing label while resolving patches.", "label=" + labelPosition.ToString());
				}

				codeStream.Position = p.Position;

				// Compute relative branch offset
				int relOffset = labelPosition - ((int)p.Position + 4);

				// Write relative offset to stream
				var bytes = BitConverter.GetBytes(relOffset);
				codeStream.Write(bytes, 0, bytes.Length);
			}

			// Reset the position
			codeStream.Position = currentPosition;
		}

		/// <summary>
		/// Emits a far jump to next instruction.
		/// </summary>
		public void EmitFarJumpToNextInstruction()
		{
			codeStream.WriteByte(0xEA);

			linker.Link(LinkType.AbsoluteAddress, PatchType.I4, MethodName, SectionKind.Text, (int)codeStream.Position, 6, MethodName, SectionKind.Text, (int)codeStream.Position);

			codeStream.WriteZeroBytes(4);
			codeStream.WriteByte(0x08);
			codeStream.WriteByte(0x00);
		}

		/// <summary>
		/// Calculates the value of the modR/M byte and SIB bytes.
		/// </summary>
		/// <param name="regField">The modR/M regfield value.</param>
		/// <param name="op1">The destination operand.</param>
		/// <param name="op2">The source operand.</param>
		/// <param name="sib">A potential SIB byte to emit.</param>
		/// <param name="displacement">An immediate displacement to emit.</param>
		/// <returns>The value of the modR/M byte.</returns>
		private static byte? CalculateModRM(byte? regField, Operand op1, Operand op2, out byte? sib, out Operand displacement)
		{
			byte? modRM = null;
			displacement = null;

			// FIXME: Handle the SIB byte
			sib = null;

			Operand mop1 = null;    // not necessary anymore
			Operand mop2 = null;    // not necessary anymore

			bool op1IsRegister = (op1 != null) && op1.IsCPURegister;
			bool op2IsRegister = (op2 != null) && op2.IsCPURegister;

			// Normalize the operand order
			if (!op1IsRegister && op2IsRegister)
			{
				// Swap the memory operands
				op1 = op2;
				op2 = null;
				mop2 = mop1;
				mop1 = null;
				op1IsRegister = op2IsRegister;
				op2IsRegister = false;
			}

			if (regField != null)
				modRM = (byte)(regField.Value << 3);

			if (op1IsRegister && op2IsRegister)
			{
				// mod = 11b, reg = rop1, r/m = rop2
				modRM = (byte)((3 << 6) | (op1.Register.RegisterCode << 3) | op2.Register.RegisterCode);
			}
			else if (mop2 != null)
			{
				// mod = 10b, r/m = mop1, reg = rop2
				modRM = (byte)(modRM.GetValueOrDefault() | 5);
				if (op1IsRegister)
					modRM |= (byte)(op1.Register.RegisterCode << 3);
				displacement = mop2;
			}
			else if (mop1 != null)
			{
				// mod = 10b, r/m = mop1, reg = rop2
				modRM = (byte)(modRM.GetValueOrDefault() | 5);
				if (op2IsRegister)
					modRM |= (byte)(op2.Register.RegisterCode << 3);
				displacement = mop1;
			}
			else if (op1IsRegister)
			{
				modRM = (byte)(modRM.GetValueOrDefault() | (3 << 6) | op1.Register.RegisterCode);
			}

			return modRM;
		}

		#endregion Code Generation
	}
}
