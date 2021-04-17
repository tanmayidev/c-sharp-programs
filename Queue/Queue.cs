using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// Dance floor  3 couple at a times.
// Male female queue,
// linked list 
// F1 -> F2 -> F3 -> F4
// M1 -> M2 -> M3 
// PQ3 -> PQ0 -> PQ1
// PQ3 -> PQ1
/*
 *  F Jennifer Ingram
    M Frank Opitz
    M Terrill Beckerman
    M Mike Dahly
    F Beata Lovelace
    M Raymond Williams
    F Shirley Yaw
    M Don Gundolf
    F Bernica Tackett
    M David Durr
    M Mike McMillan
    F Nikki Feldman
 * */

public struct pqItem {
    public int priority;
    public string name;

}
public class PQueue : Queue {
    public PQueue() {
    }
    public override Object Dequeue() {
        object[] items = this.ToArray();
        int min, minindex = -1;

        min = ((pqItem)items[0]).priority;
        for (int x = 1; x <= items.GetUpperBound(0); x++)
            if (((pqItem)items[x]).priority < min) {
                min = ((pqItem)items[x]).priority;
                minindex = x;
            }
        this.Clear();
        for (int x = 0; x <= items.GetUpperBound(0); x++)
            if (x != minindex && ((pqItem)items[x]).name != "")
                this.Enqueue(items[x]);
        return items[minindex];
    }
    static void Main() {
       PQueue erwait = new PQueue();
       pqItem[] erPatient = new pqItem[4];
       pqItem nextPatient;
       erPatient[0].name = "Joe Smith";
       erPatient[0].priority = 1;
       erPatient[1].name = "Mary Brown";
       erPatient[1].priority = 0;
       erPatient[2].name = "Sam Jones";
       erPatient[2].priority = 3;
       for (int x = 0; x <= erPatient.GetUpperBound(0); x++)
           erwait.Enqueue(erPatient[x]);
       nextPatient = (pqItem) erwait.Dequeue();
       Console.WriteLine(nextPatient.name);
    }
    
}

public class CQueue {
    private ArrayList pqueue;
    public CQueue() {
        pqueue = new ArrayList();
    }
    public void EnQueue(object item) {
        pqueue.Add(item);
    }
    public void DeQueue() {
        pqueue.RemoveAt(0);
    }
    public object Peek() {
        return pqueue[0];
    }
    public void ClearQueue() {
        pqueue.Clear();
    }

    public int Count() {
        return pqueue.Count;
    }
}