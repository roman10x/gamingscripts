using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqExamples : MonoBehaviour
{
    //Object Initializer Syntax to initialize list of people
    List<Person> personList = new List<Person>()
    {
        new Person(true, "Bob", "Roberts"),
        new Person(true, "Bill", "Williams"),
        new Person(true, "Bob", "Saginowski")
    };

    //Unity standard Start function
    void Start()
    {
        //Normal foreach to set all person.isAlive to false
        foreach (Person _person in personList)
        {
            _person.isAlive = false;
        }

        //Not Linq! Simple lambda and anonymous function equivalent to above foreach loop
        personList.ForEach(_person => _person.isAlive = false);



        //We Create new list to hold person objects with first name bob
        List<Person> listOfBobs = new List<Person>();

        //Iterate over the list, and add people with first name "Bob" to the listOfBobs
        foreach (Person _person in personList)
        {
            if (_person.firstName == "Bob")
            {
                listOfBobs.Add(_person);
            }
        }


        //Create a list using WHERE made only of people whose first name is "Bob"
        List<Person> listOfBobsUsingWhere = personList.Where(_person => _person.firstName == "Bob").ToList();

        //Filter out the person objects WHERE firstName "Bob" and isAlive is true.
        List<Person> listOfAliveBobs = personList.Where(_person => _person.firstName == "Bob" && _person.isAlive == true).ToList();



        //Returns true if ALL person objects in personList have isAlive set to true
        bool areAllAlive = personList.All(_person => _person.isAlive);



        //Returns true if ANY person objects in personList have isAlive set to true
        bool areAnyAlive = personList.Any(_person => _person.isAlive);



        //List created by selecting the first name of each person Object
        List<string> firstNameList = personList.Select(_person => _person.firstName).ToList();



        //Person List ordered by first name alphabetically
        List<Person> orderedPersonList = personList.OrderBy(_person => _person.firstName).ToList();

        //Using the same List
        personList = personList.OrderBy(_person => _person.firstName).ToList();

        //Person List ordered by descending first name alphabetically
        List<Person> orderedByDescendingPersonList = personList.OrderByDescending(_person => _person.firstName).ToList();

        //List OrderedBy SELECTED first names WHERE isAlive is true
        List<string> orderedFirstNameListOfAlivePeople = 
            personList.Where(_person => _person.isAlive).OrderBy(_person => _person.firstName).Select(_person => _person.firstName).ToList();
    }

    //Equivalent signature of anonymous function (person => _person.isAlive = false);
    void SetIsAliveToFalse(Person _person)
    {
        _person.isAlive = false;
    }
}


//Person class with constructor for each member
public class Person
{
    public Person(bool _isAlive, string _firstName, string _lastName)
    {
        isAlive = _isAlive;
        firstName = _firstName;
        lastName = _lastName;
    }

    public bool isAlive;

    public string firstName;
    public string lastName;
}

