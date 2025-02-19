// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// DivR8
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class DivR8 : BaseIRTransform
{
	public DivR8() : base(IRInstruction.DivR8, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		Translate(transform, context, ARMv8A32.Dvf, true);
	}
}
