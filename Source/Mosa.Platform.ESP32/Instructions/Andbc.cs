// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ESP32.Instructions
{
	/// <summary>
	/// Andbc - Boolean And with Complement, ANDBC performs the logical and of Boolean register bs with the logical complement of Boolean register bt, and writes the result to Boolean register br.
	/// </summary>
	/// <seealso cref="Mosa.Platform.ESP32.ESP32Instruction" />
	public sealed class Andbc : ESP32Instruction
	{
		public override int ID { get { return 705; } }

		internal Andbc()
			: base(1, 3)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 3);

			emitter.OpcodeEncoder.AppendNibble(0b0001);
			emitter.OpcodeEncoder.AppendNibble(0b0010);
			emitter.OpcodeEncoder.AppendNibble(node.Result.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(node.Operand1.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(node.Operand2.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(0b0000);
		}
	}
}
