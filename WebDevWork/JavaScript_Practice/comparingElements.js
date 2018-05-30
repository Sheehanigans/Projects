//Note: we can initialize and array by putting a list of elements in square brackets. 
//also note that javascript is loosely types which mean sit allows us to mix types in our arrays
//and that can cause all sorts of confusion 
//mixing element types like this is a "bad" practice 
//we are doing this to show how javascript can do these and how javascript can treat string like numbers for each of the elements in our array

var testArray = [0, 1, 1, "1", 3, "311"];

//Since we are comparing ahead (to the next element), we need to stop with the last 2 elements 
//The (testArray.length - 1) will get us to the last 2 elements in the array

for (var arrayPosition = 0; 
    arrayPosition < testArray.length - 1; arrayPosition++)
    {
        //We are going to store the elements we are comparing in variables to make the code more readable

        var currentElement = testArray[arrayPosition];
        var nextElement = testArray[arrayPosition + 1];

        //is currentElement greater than nextElement? 

        console.log("Testing " + currentElement + " and " + nextElement + "(greater than): " + (currentElement > nextElement)); 

        // Is currentElement less than or equal to nextElement? 

        console.log("Testing " + currentElement + " and " + nextElement + "(less than or equal to): " + (currentElement <= nextElement));

        //Are they equal to (==) each other? 
        if (currentElement == nextElement)
        {
            //If they are equal to each other (==) are they strictly equal (===) each other?
            
            console.log("Testing " + currentElement + " and " + nextElement + "(strictly equal to): " + (currentElement === nextElement));

            //If they are not strictly equal, what are their types? 

            if (currentElement !== nextElement) 
            {
                //We can use the typeof() element in Javascript to identify the type of the element

                console.log(currentElement + " is " + typeof(currentElement));
                console.log(nextElement + " is " + typeof(nextElement)); 
            } 
        } else 
            {
            console.log("Testing " + currentElement + " and " + nextElement + "(equal to): false");
            }
    }

