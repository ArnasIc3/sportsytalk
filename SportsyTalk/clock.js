function showclock() {
    let today = new Date();
    let hours = today.getHours();
    let mins = today.getMinutes();
    let seconds = today.getSeconds();
    function addZero(num) {
        if (num < 10) { return '0' + num; };
        return num;
    }
    $('#hour').text(addZero(hours));
    $('#min').text(addZero(mins));
    $('#second').text(addZero(seconds));
  }
  setInterval(showclock, 1000);