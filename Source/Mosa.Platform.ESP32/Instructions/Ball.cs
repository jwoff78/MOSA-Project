// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ESP32.Instructions
{
	/// <summary>
	/// Ball - Branch if All Bits Set, BALL branches if all the bits specified by the mask in address register at are set in address register as. The test is performed by taking the bitwise logical and of at and the complement of as, and testing if the result is zero. The target instruction address of the branch is given by the address of the BALL instruction, plus the sign-extended 8-bit imm8 field of the instruction plus four. If any of the masked bits are clear, execution continues with the next sequential instruction. The inverse of BALL is BNALL.
	/// </summary>
	/// <seealso cref="Mosa.Platform.ESP32.ESP32Instruction" />
	public sealed class Ball : ESP32Instruction
	{
		public override int ID { get { return 708; } }

		internal Ball()
			: base(1, 3)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 3);

			emitter.OpcodeEncoder.Append8BitImmediate(node.Operand2);
			emitter.OpcodeEncoder.AppendNibble(0b0100);
			emitter.OpcodeEncoder.AppendNibble(node.Operand1.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(node.Operand2.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(0b0111);
		}
	}
}
