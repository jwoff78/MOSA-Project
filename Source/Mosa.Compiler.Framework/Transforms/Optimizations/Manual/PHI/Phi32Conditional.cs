﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Manual.Phi;

public sealed class Phi32Conditional : BaseTransform
{
	public Phi32Conditional() : base(IRInstruction.Phi32, TransformType.Manual | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (context.OperandCount != 2)
			return false;

		if (!context.Operand1.IsResolvedConstant)
			return false;

		if (!context.Operand2.IsResolvedConstant)
			return false;

		if (context.PhiBlocks[0].PreviousBlocks.Count != 1)
			return false;

		if (context.PhiBlocks[1].PreviousBlocks.Count != 1)
			return false;

		if (context.PhiBlocks[0].PreviousBlocks[0] != context.PhiBlocks[1].PreviousBlocks[0])
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var parent = context.PhiBlocks[0].PreviousBlocks[0];
		var op1 = context.Operand1;
		var op2 = context.Operand2;
		var result = context.Result;
		var block1 = context.PhiBlocks[0];
		var block2 = context.PhiBlocks[1];

		var ctx = new Context(parent.BeforeLast);

		while (ctx.IsEmptyOrNop || !ctx.Instruction.IsConditionalBranch)
		{
			ctx.GotoPrevious();
		}

		var op1Condition = ctx.Operand1;
		var op2Condition = ctx.Operand2;
		var condition = ctx.ConditionCode;
		var instruction = ctx.Instruction;
		var branch = ctx.BranchTargets[0];

		var resultCondition = transform.VirtualRegisters.Allocate(result);
		var conditionInstruction = instruction == IRInstruction.Branch32 ? IRInstruction.Compare32x32 : IRInstruction.Compare64x64;
		var swap = block1 == branch;

		ctx.GotoPrevious();

		ctx.AppendInstruction(conditionInstruction, condition, resultCondition, op1Condition, op2Condition);
		ctx.AppendInstruction(IRInstruction.IfThenElse32, result, resultCondition, swap ? op1 : op2, swap ? op2 : op1);

		context.SetNop();
	}
}
