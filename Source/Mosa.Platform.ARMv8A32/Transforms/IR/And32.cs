// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// And32
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class And32 : BaseIRTransform
{
	public And32() : base(IRInstruction.And32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		TransformContext.MoveConstantRight(context);

		Translate(transform, context, ARMv8A32.And, true);
	}
}
