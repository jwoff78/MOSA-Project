// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// LoadSignExtend8x32
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class LoadSignExtend8x32 : BaseIRInstruction
{
	public LoadSignExtend8x32()
		: base(2, 1)
	{
	}

	public override bool IsMemoryRead => true;
}
