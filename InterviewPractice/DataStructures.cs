using System;
using System.Collections;
using System.Collections.Generic;
namespace GoogleInterviewPractice
{
	public class DataStructures
	{
		public DataStructures ()
		{

		}
	}

	public class myQueue<T>
	{
		List<T> innerList;

		public myQueue()
		{
			innerList = new List<T> ();
		}
		public T dequeue()
		{
			if (innerList == null || innerList.Count==0)
				return default(T);
			T data = innerList [0];
			innerList.RemoveAt (0);
			return data;
		}
		public void enqueue (T data)
		{
			innerList.Add (data);
		}
		public int Length()
		{
			return innerList.Count;
		}
		public void clear()
		{
			innerList.Clear ();
		}
		public T peek()
		{
			if (innerList == null || innerList.Count==0)
				return default(T);
			return innerList [0];
		}
	}
	public class myStack<T>
	{
		List<T> innerList;
		//pindex determines at which index I should pop the data
		int pindex;

		public myStack()
		{
			innerList = new List<T> ();
			pindex = -1;
		}
		public T pop()
		{
			T data;
			//Exit condition
			if (pindex == -1)
				return default(T);

			data = innerList [pindex];
			innerList.RemoveAt (pindex);
			pindex--;
			return data;
		}
		public void push (T data)
		{
			innerList.Add (data);
			pindex++;
		}
		public int Length()
		{
			return innerList.Count;
		}
		public void clear()
		{
			innerList.Clear ();
		}
		public T peek()
		{
			//Exit condition
			if (pindex == -1)
				return default(T);

			return innerList [pindex];
		}
	}

	public class Node<T>
	{
		T _data;
		Node<T> _link;
		Node<T> _previous;

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

	public class MySinglyLinkedList<T>
	{
		Node<T> _header;
		int _count;

		public int Count
		{
			get { return _count;}
			set { _count = value;}
		}

		public MySinglyLinkedList()
		{
			_header = new Node<T>();
			_count = 0;
		}

		public void addNode(T data)
		{
			Node<T> current = findNode(data);
			Node<T> newNode = new Node<T> (data, null);
			current.Link = newNode;
			_count++;
		}

		protected Node<T> findLastNode()
		{
			Node<T> current = _header;
			while (current != null && current.Link != null) 
			{
				current = current.Link;
			}
			return current;
		}

		public Node<T> findNode(T data)
		{
			Node<T> current = _header;

			while (current!=null && !current.Data.Equals(data)) 
			{
				current = current.Link;
			}
			return current;
		}

		public Node<T> findPreviousNode(T data)
		{
			Node<T> current = _header;
			Node<T> previous = null;
			while (current!=null && !current.Data.Equals( data)) 
			{
				previous = current;
				current = current.Link;
			}
			return previous;
		}

		public void removeNode(T data)
		{
			Node<T> previous = findPreviousNode(data);
			Node<T> current = findNode (data);
			if (current == null)
				return;

			previous.Link = current.Link;
			current = null;
			_count--;
		}

		public void reverse()
		{
			Node<T> current = _header, newHeader=null;
			while (current!=null) 
			{
				Node<T> temp = current.Link;
				current.Link = newHeader;
				newHeader = current;
				current = temp;
			}
			_header = newHeader;
		}

		public Node<T> findMidElement()
		{
			//Exit Conditions
			if (_header == null)
				return null;

			Node<T> fast = _header, slow = _header;
			while (fast.Link!=null) 
			{
				fast = fast.Link.Link;
				slow = slow.Link;
			}
			return slow;
		}

		public bool loopExists()
		{
			//Exit condition
			if (_header == null)
				return false;

			Node<T> slow = _header, fast = _header;
			while (fast.Link !=null) 
			{
				fast= fast.Link.Link;
				slow = slow.Link;
				if (fast == slow)
					return true;

			}
			return false;

		}

	}

	public class MyDoublyLinkedList<T>
	{
		Node<T> _header;
		int _count;

		public int Count
		{
			get { return _count;}
			set { _count = value;}
		}

		public MyDoublyLinkedList()
		{
			_header = new Node<T>();
			_count = 0;
		}

		public void addNode(T data)
		{
			Node<T> current = findNode(data);
			Node<T> newNode = new Node<T> (data, null,current);
			current.Link = newNode;
			_count++;
		}

		public Node<T> findNode(T data)
		{
			Node<T> current = _header;

			while (!current.Data.Equals( data))  
			{
				current = current.Link;
			}
			return current;
		}



		public void removeNode(T data)
		{
			Node<T> current = findNode (data);
			current.Previous.Link = current.Link;
			current.Link.Previous = current.Previous;
			current.Link = null;
			current.Previous = null;
			Count--;
		
		}

	}




}

