function countingCharacters(stringToCount){
    //the lenth the property has been mentioned in the logging letter excersize in lesson 4
    console.log(stringToCount + " has " + stringToCount.length + " characters.");
}
function countingCharacters2(stringToCount, characterToFind){
    //count the number of times a achracter appears in a string 
    //use a for loop to look at each charcter one by one 
    var characterCount = 0;
    for (var characterPosition = 0;
            characterPosition < stringToCount.length;
            characterPosition++){
        if (stringToCount[characterPosition] == characterToFind){
            characterCount++;
        }
    }
    console.log("string to search in: " + stringToCount);
    console.log("Character to find: " + characterToFind);
    console.log("Number of times the character appears: " + 
                    characterCount);
}

//str - string to search
//search - characters to find in the str
function countingCharacters3(str, search){
    var count = 0; //number found 
    var numChars = search.length; 
    /*we need to stop the loop based on a multiple character example: 
    if searching "Ohio" with 3 characters at a time, we want to stop
    at the h so we do not go past the string*/
    var lastIndex = str.length - numChars;
    //we will use a for loop to go through the string
    //this time we are looking for a series of charcters - a substring 
        for (var index = 0; index <= lastIndex; index++)
        {
            //substring gets a part of the string from start to end index
            var current = str.substring(index, index + numChars);
            //if the substring matches our series, increase our counter 
            if (current == search){
                count++;
            }
        }
        return count;
    /*console.log("String to search in: " + str);
    console.log("String to find: " + search);
    console.log("Number of times the character appears: " + count);*/
}