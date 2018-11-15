// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Ldrh32 - Load 16-bit unsigned halfword
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Ldrh32 : ARMv6Instruction
	{
		public override int ID { get { return 720; } }

		internal Ldrh32()
			: base(1, 3)
		{
		}
	}
}
