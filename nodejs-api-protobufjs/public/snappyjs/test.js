//var SnappyJS = require('snappyjs')
//var buffer = new ArrayBuffer(100)
//// fill data in buffer
//var compressed = SnappyJS.compress(buffer)
//var uncompressed = SnappyJS.uncompress(compressed)

'use strict'

function arrayBufferEquals(buffer1, buffer2) {
    if (buffer1.byteLength !== buffer2.byteLength) {
        return false
    }
    var view1 = new Uint8Array(buffer1)
    var view2 = new Uint8Array(buffer1)
    var i
    for (i = 0; i < view1.length; i++) {
        if (view1[i] !== view2[i]) {
            return false
        }
    }
    return true
}

var fileInput = document.getElementById('input')
var output = document.getElementById('output')

fileInput.addEventListener('change', function (e) {
    var file = fileInput.files[0]
    var reader = new FileReader()
    reader.onload = function (e) {
        var contentBuffer = reader.result
        var compressed = SnappyJS.compress(contentBuffer)
        var uncompressed = SnappyJS.uncompress(compressed)
        if (arrayBufferEquals(uncompressed, contentBuffer)) {
            output.innerHTML = 'Original byte size: ' + contentBuffer.byteLength + '<br>' +
                'Compressed byte size: ' + compressed.byteLength
        } else {
            window.alert('Test failed!')
        }
    }
    reader.readAsArrayBuffer(file)
})


