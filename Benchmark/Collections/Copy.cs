using System.Collections;

namespace Benchmark.Collections;

public class Copy
{
    public static void SpreadOperator()
    {
        var person = new Person()
        {
            Name = "Anderson Silva",
            Address = new Address()
            {
                City = "São Paulo"
            }
        };

        List<Person> people = new List<Person>() { person };
        PeopleEnum people2 = [.. people];

        people2[0].Address.City = "Rio de Janeiro";
        people2[0].Name = "Tomás Aquino";
        
        Console.WriteLine(people[0].Name);
        Console.WriteLine(people[0].Address.City);
    }

    public void MemberwiseClone()
    {
        
    }
}


public class Person
{
    public string Name { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string City { get; set; }
}

public class PeopleEnum : IEnumerable<Person>, IEnumerator
{
    public Person[] _people;
    internal int _size;
    
    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;
    private static readonly Person[] s_emptyArray = new Person[0];
    
    public PeopleEnum() => this._people = PeopleEnum.s_emptyArray;
    
    public PeopleEnum(IEnumerable<Person> collection)
    {
        if (collection == null)
            throw new ArgumentOutOfRangeException();
        if (collection is ICollection<Person> objs)
        {
            int count = objs.Count;
            if (count == 0)
            {
                this._people = PeopleEnum.s_emptyArray;
            }
            else
            {
                this._people = new Person[count];
                objs.CopyTo(this._people, 0);
                this._size = count;
            }
        }
        else
        {
            this._people = PeopleEnum.s_emptyArray;
            foreach (Person obj in collection)
                this.Add(obj);
        }
    }
    
    public Person this[int index]
    {
        get
        {
            if ((uint)index >= (uint)this._size)
                throw new IndexOutOfRangeException();
            return this._people[index];
        }
        set
        {
            if ((uint) index >= (uint) this._size)
                throw new IndexOutOfRangeException();
            this._people[index] = value;
            //++this._version;
        }
    }

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return new Person() { Name = _people[position].Name };
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public IEnumerator<Person> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public void Add(Person item)
    {
        //++this._version;
        Person[] items = this._people;
        int size = this._size;
        if ((uint) size < (uint) items.Length)
        {
            this._size = size + 1;
            items[size] = item;
        }
        
    }
}