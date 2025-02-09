﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Diagnostics.Contracts;

namespace System.Collections;

// Useful base class for typed read/write collections where items derive from object
[Serializable]
public abstract class CollectionBase : IList
{
	private ArrayList list;

	protected CollectionBase()
	{
		list = new ArrayList();
	}

	protected CollectionBase(int capacity)
	{
		list = new ArrayList(capacity);
	}

	protected ArrayList InnerList
	{
		get
		{
			if (list == null)
				list = new ArrayList();
			return list;
		}
	}

	protected IList List
	{
		get { return this; }
	}

	public int Capacity
	{
		get
		{
			return InnerList.Capacity;
		}
		set
		{
			InnerList.Capacity = value;
		}
	}

	public int Count
	{
		get
		{
			return list == null ? 0 : list.Count;
		}
	}

	public void Clear()
	{
		OnClear();
		InnerList.Clear();
		OnClearComplete();
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= Count)
			throw new ArgumentOutOfRangeException();

		//throw new ArgumentOutOfRangeException(nameof(index), Environment.GetResourceString("ArgumentOutOfRange_Index"));
		Contract.EndContractBlock();
		Object temp = InnerList[index];
		OnValidate(temp);
		OnRemove(index, temp);
		InnerList.RemoveAt(index);
		try
		{
			OnRemoveComplete(index, temp);
		}
		catch
		{
			InnerList.Insert(index, temp);

			//throw; FIME: --- not support!
		}
	}

	bool IList.IsReadOnly
	{
		get { return InnerList.IsReadOnly; }
	}

	bool IList.IsFixedSize
	{
		get { return InnerList.IsFixedSize; }
	}

	bool ICollection.IsSynchronized
	{
		get { return InnerList.IsSynchronized; }
	}

	Object ICollection.SyncRoot
	{
		get { return InnerList.SyncRoot; }
	}

	void ICollection.CopyTo(Array array, int index)
	{
		InnerList.CopyTo(array, index);
	}

	Object IList.this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
				throw new ArgumentOutOfRangeException();

			//throw new ArgumentOutOfRangeException(nameof(index), Environment.GetResourceString("ArgumentOutOfRange_Index"));
			Contract.EndContractBlock();
			return InnerList[index];
		}
		set
		{
			if (index < 0 || index >= Count)
				throw new ArgumentOutOfRangeException();

			//throw new ArgumentOutOfRangeException(nameof(index), Environment.GetResourceString("ArgumentOutOfRange_Index"));
			Contract.EndContractBlock();
			OnValidate(value);
			Object temp = InnerList[index];
			OnSet(index, temp, value);
			InnerList[index] = value;
			try
			{
				OnSetComplete(index, temp, value);
			}
			catch
			{
				InnerList[index] = temp;

				//throw; FIME: --- not support!
			}
		}
	}

	bool IList.Contains(Object value)
	{
		return InnerList.Contains(value);
	}

	int IList.Add(Object value)
	{
		OnValidate(value);
		OnInsert(InnerList.Count, value);
		int index = InnerList.Add(value);
		try
		{
			OnInsertComplete(index, value);
		}
		catch
		{
			InnerList.RemoveAt(index);

			//throw; FIME: --- not support!
		}
		return index;
	}

	void IList.Remove(Object value)
	{
		OnValidate(value);
		int index = InnerList.IndexOf(value);
		if (index < 0) throw new ArgumentException();//throw new ArgumentException(Environment.GetResourceString("Arg_RemoveArgNotFound"));
		OnRemove(index, value);
		InnerList.RemoveAt(index);
		try
		{
			OnRemoveComplete(index, value);
		}
		catch
		{
			InnerList.Insert(index, value);

			//throw; FIME: --- not support!
		}
	}

	int IList.IndexOf(Object value)
	{
		return InnerList.IndexOf(value);
	}

	void IList.Insert(int index, Object value)
	{
		if (index < 0 || index > Count)
			throw new ArgumentOutOfRangeException();

		//throw new ArgumentOutOfRangeException(nameof(index), Environment.GetResourceString("ArgumentOutOfRange_Index"));
		Contract.EndContractBlock();
		OnValidate(value);
		OnInsert(index, value);
		InnerList.Insert(index, value);
		try
		{
			OnInsertComplete(index, value);
		}
		catch
		{
			InnerList.RemoveAt(index);

			//throw; FIME: --- not support!
		}
	}

	public IEnumerator GetEnumerator()
	{
		return InnerList.GetEnumerator();
	}

	protected virtual void OnSet(int index, Object oldValue, Object newValue)
	{
	}

	protected virtual void OnInsert(int index, Object value)
	{
	}

	protected virtual void OnClear()
	{
	}

	protected virtual void OnRemove(int index, Object value)
	{
	}

	protected virtual void OnValidate(Object value)
	{
		if (value == null) throw new ArgumentNullException(nameof(value));
		Contract.EndContractBlock();
	}

	protected virtual void OnSetComplete(int index, Object oldValue, Object newValue)
	{
	}

	protected virtual void OnInsertComplete(int index, Object value)
	{
	}

	protected virtual void OnClearComplete()
	{
	}

	protected virtual void OnRemoveComplete(int index, Object value)
	{
	}
}
