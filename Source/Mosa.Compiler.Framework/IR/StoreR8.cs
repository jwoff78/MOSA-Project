// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// StoreR8
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class StoreR8 : BaseIRInstruction
{
	public StoreR8()
		: base(3, 0)
	{
	}

	public override bool IsMemoryWrite => true;
}
