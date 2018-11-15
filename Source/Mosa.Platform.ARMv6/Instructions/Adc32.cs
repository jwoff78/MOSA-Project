// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;
using Mosa.Compiler.Common;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Adc32 - Add with Carry
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Adc32 : ARMv6Instruction
	{
		public override int ID { get { return 698; } }

		internal Adc32()
			: base(1, 3)
		{
		}

		public override bool IsCommutative { get { return true; } }

		public override bool IsCarryFlagUsed { get { return true; } }

		protected override void Emit(InstructionNode node, ARMv6CodeEmitter emitter)
		{
			EmitDataProcessingInstruction(node, emitter, Bits.b0101);
		}
	}
}
