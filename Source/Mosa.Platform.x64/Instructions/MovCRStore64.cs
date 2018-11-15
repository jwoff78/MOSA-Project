// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// MovCRStore64
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class MovCRStore64 : X64Instruction
	{
		public override int ID { get { return 494; } }

		internal MovCRStore64()
			: base(0, 2)
		{
		}

		public static readonly LegacyOpCode LegacyOpcode = new LegacyOpCode(new byte[] { 0x0F, 0x22 });

		public override bool IsMemoryWrite { get { return true; } }

		internal override void EmitLegacy(InstructionNode node, X64CodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 0);
			System.Diagnostics.Debug.Assert(node.OperandCount == 2);

			emitter.Emit(LegacyOpcode, node.Operand1, node.Operand2);
		}
	}
}
