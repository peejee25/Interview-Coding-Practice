using System;
using System.Collections.Generic;
using System.Text;


namespace GoogleInterviewPractice
{
	public class PracticeDS
	{
		public PracticeDS ()
		{
		}
	}

	public class myQueue<T>
	{
		private List<T> _innerList;
		public myQueue()
		{
			_innerList = new List<T> ();
		}
		public void enqueue(T data)
		{
			if (data.Equals (default(T)))
				return;
			
			_innerList.Add (data);
		}
		public T dequeue()
		{
			T data;
			if (this.Length == 0)
				return default(T);
			else 
			{
				data = _innerList [0];
				_innerList.RemoveAt (0);
				return data;
			}
		}
		public int Length
		{
			get { return _innerList.Count; }
		}
		public void clear()
		{
			_innerList.Clear ();
		}
		public T peek()
		{
			T data;
			if (this.Length == 0)
				return default(T);
			else 
			{
				data = _innerList [0];
				return data;
			}
		}


	}

	public class myStack<T>
	{
		private List<T> _innerList;
		private int _pindex;
		public myStack()
		{
			_innerList = new List<T>();
			_pindex=-1;
		}

		public void push(T data)
		{
			if (data.Equals(default(T)))
				return;
			_innerList.Add (data);
			_pindex++;
		}
		public T pop()
		{
			T data;
			if (this.Length == 0)
				return default(T);
			else 
			{
				data = _innerList [_pindex];
				_innerList.RemoveAt (_pindex);
				_pindex--;
				return data;
			}
		}
		public void clear()
		{
			_innerList.Clear ();
		}
		public T peek()
		{
			T data;
			if (this.Length == 0)
				return default(T);
			else 
			{
				data = _innerList [_pindex];
				return data;
			}
		}
		public int Length {
			get { return _pindex + 1; }
		}
	}

	public class Node<T>
	{
		private T _data;
		private Node<T> _link;
		private Node<T> _previous;

		public Node()
		{
			this._data = default(T);
			this._link = null;
			this._previous = null;
		}
		public Node(T data, Node<T> link)
		{
			this._data = data;
			this._link = link;
			this._previous = null;
		}

		public Node(T data, Node<T> link,Node<T> previous)
		{
			this._data = data;
			this._link = link;
			this._previous = previous;
		}

		public Node(T data)
		{
			this._data = data;
			this._link = null;
			this._previous = null;
		}
		public T Data
		{
			get { return this._data;}
			set { this._data = value;}
		}

		public Node<T> Link
		{
			get { return this._link;}
			set { this._link = value;}
		}
		public Node<T> Previous
		{
			get { return this._previous;}
			set { this._previous = value;}
		}
	}

	public class mySinglyLinkedList<T>
	{
		private Node<T> _header;
		private int _count;

		public int Count
		{
			get { return _count;}
			set { _count = value;}
		}

		public mySinglyLinkedList()
		{
			_header = new Node<T>();
			_count = 0;
		}
		public void addNode(T data)
		{
			Node<T> current = _header;
			if (Count == 0) {
				_header.Data = data;
				Count++;
				return;
			}
			while (current != null && current.Link !=null) 
			{
				current = current.Link;
			}
			Node<T> newNode = new Node<T> (data);
			current.Link = newNode;
			Count++;
		}
		public Node<T> findNode(T data)
		{
			Node<T> current = _header;
			if (Count == 0) {
				return null;
			}
			while (current != null) {
				if (current.Data.Equals (data))
					return current;
				current = current.Link;
			}
		}
		public Node<T> findPreviousNode(T data)
		{
			Node<T> current = _header;
			if (Count <=1) {
				return null;
			}
			Node<T> previousNode = null;
			while (current != null) {
				if (current.Data.Equals (data))
					return previousNode;
				previousNode = current; 
				current = current.Link;
			}
		}
		public void removeNode(T data)
		{
			if (Count == 0)
				return;
			if (Count == 1 && _header.Data.Equals (data)) {
				_header.Data == default(T);
				Count--;
				return;
			}

			Node<T> matchedNode = findNode (data);
			if (matchedNode == null)
				return;
			Node<T> previousNode = findPreviousNode (data);
			if (previousNode == null)
				throw new Exception ("Previous Node null, when expected to be not null");
			previousNode.Link = matchedNode.Link;
			matchedNode = null; 
			Count--;

		}
		public void reverse()
		{
			Node<T> temp, current = _header, newheader = null;
			while (current!=null) {
				temp = current.Link;
				current.Link = newheader;
				newheader = current;
				current = temp;
			}
			_header = newheader;

		}
		public Node<T> findMidElement()
		{
			Node<T> slow = _header, fast = _header;
			while (fast!= null && fast.Link!=null) {
				slow = slow.Link;
				fast = fast.Link.Link;
				if (slow == fast)
					break;

			}
			return slow;
		}
		public bool loopExists()
		{

			Node<T> slow = _header, fast = _header;
			while (fast!= null && fast.Link!=null) {
				slow = slow.Link;
				fast = fast.Link.Link;
				if (slow == fast)
					return true;

			}
			return false;
		}
	}

}

