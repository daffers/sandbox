var request = require("superagent");
var expect = require("expect.js");

describe('Suite one', function () {
    it(function (done) {
        request.post('localhost:8080').end(function (res) {
            expect(res).to.exist;
            expect(res.status).to.equal(200);
            expect(res.body).to.contain('world');
            done();
        });
    });
});