// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Transforms.IR;

/// <summary>
/// GetLow32
/// </summary>
[Transform("ARMv8A32.IR")]
public sealed class GetLow32 : BaseIRTransform
{
	public GetLow32() : base(IRInstruction.GetLow32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		transform.SplitOperand(context.Result, out var resultLow, out _);
		transform.SplitOperand(context.Operand1, out var op1L, out _);

		op1L = MoveConstantToRegisterOrImmediate(transform, context, op1L);

		context.SetInstruction(ARMv8A32.Mov, resultLow, op1L);
	}
}
