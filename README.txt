Author: Khadir Abdullah
Date: 6/17/2016

This is the Pig Latin Translator, a console application which translates user input into pig latin translations.

The program takes in user a line of user input and returns the pig latin translation. Users can exit the program by
typing 'exit'. The 'exit' command is case-sensitive.

ARCHITECTURE

Most of the work within the program occurs within the PigLatinTranslator class. The PigLatinTranslator class has two
main functions, PigLatinTranslate and SingleWordPigLatinTranslate. PigLatinTranslate translates the users input phrase
by iterating over the words in the phrase, calling SingleWordPigLatinTranslate. SingleWordPigLatinTranslate
utilizes multiple helper functions SeparatePunctuation, ContainsConsonant, and CapitalizeFirstCharacter to meet
the given requirements. After separating the punctuation, SWPLT substrings the prefix and the stem, and then appends 
the appropriate suffix (based on the result of ContainsConsonant) as well as the punctuation. Then, the first letter
is capitalized if needed be.

ASSUMPTIONS
I'm assuming all input is valid, as per the requirements. As of 6/17/2016, there is no input validation 
(although that could change this weekend if I get the time).
A valid input is an input that is input made up of characters, numbers, spaces, and the {, ! ?} punctuations.
The requirements don't mention what should happen in the event multiple capitalized letters exist within a word, like an acronym.
In these instances, this translator simply characterizes the first letter and makes no attempt to capitalize any remaining words, as that
would require making too many assumptions about the user's intent.  

INSTANCES WHERE THE SAMPLE OUTPUT VARIED FROM THE REQUIREMENTS

I also noticed that two lines in the sample output were inconsistent with the requirements:

Per the requirements, "eosshay" below should be "oesshay", however the sample output (see below) has it spelled
differently. Also, "uddybah" in the second sample output should be "uddybay". I assumed that both of these were 
typos instead of the correct output (which would mean the requirements were incorrect). As such, the 
PigLatinTranslator adheres to the stated requirements, not the sample output. 

--> No shirts, no shoes, no service
Onay irtsshay, onay eosshay, onay ervicesay

--> Hey buddy, get away from my car!
Eyhay uddybah, etgay awayay omfray ymay arcay!

On the same note, rule 5 says that the result of "sandwich" should be "andwichsay." with a period at the end. This seems to be
inconsistent with the intent of the rule, plus the inclusion of the period would violate rule #2, which says 
the only punctuation is {, ! ?}.

