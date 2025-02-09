// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// StoreParamR8
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class StoreParamR8 : BaseIRInstruction
{
	public StoreParamR8()
		: base(2, 0)
	{
	}

	public override bool IsMemoryWrite => true;

	public override bool IsParameterStore => true;
}
