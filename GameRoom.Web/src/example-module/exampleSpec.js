'use strict';

describe('example module', function() {

  beforeEach(module('supportPortal.example'));

  describe('example controller', function(){
    it('should exist', inject(function($controller) {
      var view1Ctrl = $controller('ExampleCtrl');
      expect(view1Ctrl).toBeDefined();
    }));
  });
});
