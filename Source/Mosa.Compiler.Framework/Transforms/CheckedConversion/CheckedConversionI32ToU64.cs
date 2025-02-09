// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.CheckedConversion;

/// <summary>
/// CheckedConversionI32ToU64
/// </summary>
public sealed class CheckedConversionI32ToU64 : BaseCheckedConversionTransform
{
	public CheckedConversionI32ToU64() : base(IRInstruction.CheckedConversionI32ToU64, TransformType.Manual | TransformType.Transform)
	{
	}

	public override int Priority => -10;

	public override bool Match(Context context, TransformContext transform)
	{
		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		CallCheckOverflow(transform, context, "I4ToU8");
	}
}
