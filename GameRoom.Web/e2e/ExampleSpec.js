'use strict';
/*global browser, by, element */
describe('example page', function(){
  it('should have example text on it', function(){
    browser.get('#/example');

    var text = element(by.css('.page-header-text h3'));
    expect(text.getText()).toEqual('Support Portal Example')
  });
});
