// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Manual.StrengthReduction;

/// <summary>
/// AddCarryOut32ByZero
/// </summary>
public sealed class AddCarryOut64ByZero : BaseTransform
{
	public AddCarryOut64ByZero() : base(IRInstruction.AddCarryOut64, TransformType.Manual | TransformType.Optimization, true)
	{
	}

	public override int Priority => 80;

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand2.IsResolvedConstant)
			return false;

		if (context.Operand2.ConstantUnsigned64 != 0)
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;
		var result2 = context.Result2;
		var operand1 = context.Operand1;

		context.SetInstruction(IRInstruction.Move64, result, operand1);
		context.AppendInstruction(IRInstruction.Move64, result2, Operand.Constant64_0);
	}
}

/// <summary>
/// AddCarryOut32ByZero2
/// </summary>
public sealed class AddCarryOut64ByZero2 : BaseTransform
{
	public AddCarryOut64ByZero2() : base(IRInstruction.AddCarryOut64, TransformType.Manual | TransformType.Optimization, true)
	{
	}

	public override int Priority => 80;

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsResolvedConstant)
			return false;

		if (context.Operand1.ConstantUnsigned64 != 0)
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;
		var result2 = context.Result2;
		var operand2 = context.Operand2;

		context.SetInstruction(IRInstruction.Move64, result, operand2);
		context.AppendInstruction(IRInstruction.Move64, result2, Operand.Constant64_0);
	}
}
