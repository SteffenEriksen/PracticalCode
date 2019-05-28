
// map makes a string[] into a new array of object[]
countries.map(country => ({
    countryCode: country
}))


// Summarize a field within an object-array
// Default value is 0 if the array is undefined
refunds.map((i) => i.amount).reduce((p, n) => p + n, 0)


// Make array of object keys
// Will be an array (string[]) of the keys ["test", "test2", "test3"]
var obj = 
{
    test: {
        attribute: "string"
    },
    test2: "string",
    test3: "string",
}
var test = Object.keys(obj)

// Using the same array as above, but with filter
// Result will remove any found argument, and will give => ["test", "test3"]
test.filter(val => !val.includes('2'))