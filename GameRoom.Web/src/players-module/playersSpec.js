'use strict';

describe('example module', function() {

  beforeEach(module('gameroom.players'));

  describe('example controller', function(){
    it('should exist', inject(function($controller) {
      var view1Ctrl = $controller('LoginCtrl');
      expect(view1Ctrl).toBeDefined();
    }));
  });
});
