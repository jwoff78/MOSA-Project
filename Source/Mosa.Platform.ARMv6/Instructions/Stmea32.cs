// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Stmea32 - Store Multiple Empty Ascending
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Stmea32 : ARMv6Instruction
	{
		public override int ID { get { return 743; } }

		internal Stmea32()
			: base(1, 3)
		{
		}
	}
}
