

var uint8array = new TextEncoder("utf-8").encode("Plain Text");
var string = new TextDecoder().decode(uint8array);
console.log(uint8array, string);

/**
 * Converts an array buffer to a string
 *
 * @param {Uin8} uint8arr | The buffer to convert
 * @param {Function} callback | The function to call when conversion is complete
 */
function largeuint8ArrToString(uint8arr, callback) {
    var bb = new Blob([uint8arr]);
    var f = new FileReader();
    f.onload = function (e) {
        callback(e.target.result);
    };

    f.readAsText(bb);
}

// Usage example
// "Hello" in Uint8Array format
var myuint8Arr = new Uint8Array([72, 101, 108, 108, 111, 32, 33]);

largeuint8ArrToString(myuint8Arr, function (text) {
    // Hello
    console.log(text);
});

self.addEventListener('install', function (event) {
    
});