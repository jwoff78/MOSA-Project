// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// Inc64
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class Inc64 : X64Instruction
	{
		internal Inc64()
			: base(1, 1)
		{
		}

		public override bool IsZeroFlagModified { get { return true; } }

		public override bool IsSignFlagModified { get { return true; } }

		public override bool IsOverflowFlagModified { get { return true; } }

		public override bool IsParityFlagModified { get { return true; } }

		public override void Emit(InstructionNode node, OpcodeEncoder opcodeEncoder)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 1);

			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit((node.Result.Register.RegisterCode >> 3));
			opcodeEncoder.Append8Bits(0xFF);
			opcodeEncoder.Append2Bits(0b11);
			opcodeEncoder.Append3Bits(0b000);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
		}
	}
}
