

describe("A Javascript is stupid because", function() {
    it("comparing two different arrays return true", function() {
        expect(new Array() == new Array()).not.toBe(true);
    });

    it("when evaluating \"0\" == 0 returns true", function() {
        expect("0"==0).toBe(true);
    });
});
  
  