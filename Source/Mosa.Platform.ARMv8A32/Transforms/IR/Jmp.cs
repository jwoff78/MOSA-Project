// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// Jmp
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class Jmp : BaseIRTransform
{
	public Jmp() : base(IRInstruction.Jmp, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		context.ReplaceInstruction(ARMv8A32.B);
		context.ConditionCode = ConditionCode.Always;
	}
}
