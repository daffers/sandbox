var assert = require('assert');
var loader = required('TextLoader');

exports['Test 1'] = function (test) {
    var text = loader.SayHello();
    assert.equal("Hello from my injecto", text);
}
