// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.


export function SaveScrollPosition() {
    localStorage.setItem("scroll_position_for_backwards", window.scrollY);
}


export function RestoreScrollPosition() {
    var scrollpos = localStorage.getItem("scroll_position_for_backwards");
    if (scrollpos === null || scrollpos.length === 0) {
      
    }
    else {
        window.scrollTo(0, scrollpos);
    }
  
}


export function DeleteScrollPosition() {
    localStorage.setItem("scroll_position_for_backwards", 0);
}

export function DeleteScrollPositionKey(key) {
    localStorage.setItem("scroll_position_for_backwards"+key, 0);
}



export function SaveScrollPositionKey(key) {
    localStorage.setItem("scroll_position_for_backwards"+key, window.scrollY);
}


export function RestoreScrollPositionKey(key) {
    var scrollpos = localStorage.getItem("scroll_position_for_backwards"+key);
    if (scrollpos === null || scrollpos.length === 0) {

    }
    else {
        window.scrollTo(0, scrollpos);
    }
  
}
