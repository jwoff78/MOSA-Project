// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Diagnostics;
using Mosa.Compiler.MosaTypeSystem;

namespace Mosa.Compiler.Framework.Transforms.Exception;

/// <summary>
/// TryEnd
/// </summary>
public sealed class TryEnd : BaseExceptionTransform
{
	public TryEnd() : base(IRInstruction.TryEnd, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var label = TraverseBackToNativeBlock(context.Block).Label;
		var immediate = FindImmediateExceptionHandler(transform, label);
		var target = context.BranchTargets[0];

		Debug.Assert(immediate != null);

		if (immediate.ExceptionHandlerType == ExceptionHandlerType.Finally)
		{
			context.SetInstruction(IRInstruction.MoveObject, transform.LeaveTargetRegister, Operand.CreateConstant32(target.Label));
			context.AppendInstruction(IRInstruction.MoveObject, transform.ExceptionRegister, Operand.NullObject);
			context.AppendInstruction(IRInstruction.Jmp, transform.BasicBlocks.GetByLabel(immediate.HandlerStart));
			return;
		}

		// fixme --- jump to target unless, there is a finally before it.

		var next = FindNextEnclosingFinallyHandler(transform, immediate);

		if (next != null && next.HandlerEnd > immediate.HandlerEnd)
		{
			context.SetInstruction(IRInstruction.MoveObject, transform.LeaveTargetRegister, Operand.CreateConstant32(target.Label));
			context.AppendInstruction(IRInstruction.MoveObject, transform.ExceptionRegister, Operand.NullObject);
			context.AppendInstruction(IRInstruction.Jmp, transform.BasicBlocks.GetByLabel(next.HandlerStart));
			return;
		}

		context.SetInstruction(IRInstruction.Jmp, target);
	}
}
