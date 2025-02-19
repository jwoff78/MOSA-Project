// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// BlockEnd
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class BlockEnd : BaseIRInstruction
{
	public BlockEnd()
		: base(0, 0)
	{
	}

	public override bool IgnoreDuringCodeGeneration => true;
}
