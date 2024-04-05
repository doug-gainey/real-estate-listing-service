/// <reference path="jquery-vsdoc.js"/>
var lastIndex = 0;
var currentIndex = 0;

function initializeCarousel() {
    $('#leftarrow').click(showPrevious);
    $('#rightarrow').click(showNext);

    var listings = $('#carousel > div');
    lastIndex = listings.length - 1;
    
    var currentListing = listings.filter('.featured');
    currentIndex = listings.index(currentListing);
};

function showPrevious() {
    currentIndex = currentIndex == 0 ? lastIndex : currentIndex - 1;

    showCurrent();
}

function showNext() {
    currentIndex = currentIndex == lastIndex ? 0 : currentIndex + 1;

    showCurrent();
}

function showCurrent() {
    var listings = $('#carousel > div');
    listings.removeClass();

    var previousIndex = currentIndex == 0 ? lastIndex : currentIndex - 1;
    //$(listings[previousIndex]).animate({'marginLeft': '100px'}, 'slow');

    $(listings[previousIndex]).addClass('prev');
    
    $(listings[currentIndex]).addClass('featured');

    var nextIndex = currentIndex == lastIndex ? 0 : currentIndex + 1;
    $(listings[nextIndex]).addClass('next');
}

$(document).ready(function() {
    var textBox = $('#headersearch .textbox');
    var defaultText = textBox.val();
    textBox.focus(function() {
        if (textBox.val() == defaultText)
            textBox.val('');
    });
    textBox.blur(function() {
        if (textBox.val() == '')
            textBox.val(defaultText);
    });

    initializeCarousel();
});