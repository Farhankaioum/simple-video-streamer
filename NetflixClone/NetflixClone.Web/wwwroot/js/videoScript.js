var player = videojs('my-video');
//player.on('play', () => {
//    alert(player.currentTime());
//    submitError('buffering error', player.currentTime());
//});

function submitError(errorMessage, durationTime) {
    var videoId = $('.videoId').val();
    var data = { videoId: videoId, error: errorMessage.toString(), duration: durationTime.toString() };
    $.ajax({
        url: "/Videos/ErrorSubmit",
        type: "POST",
        contentType: 'application/x-www-form-urlencoded',
        data: data,
        success: function (data) {
            alert('added successfully');
        },
        error: function (data) {
            alert('Unsuccessfull');
        }
    });
}


player.on('ended', function () {
    console.log('ended');
});
player.on('error', function () {
    submitError(player.error(), player.currentTime());
    console.log(player.error());
});

catchBufferingError();

function catchBufferingError() {
    // for buffering error
    var checkInterval = 50.0 // check every 50 ms (do not use lower values)
    var lastPlayPos = 0
    var currentPlayPos = 0
    var bufferingDetected = false

    setInterval(checkBuffering, checkInterval)
    function checkBuffering() {
        currentPlayPos = player.currentTime()

        // checking offset should be at most the check interval
        // but allow for some margin
        var offset = (checkInterval - 20) / 1000

        // if no buffering is currently detected,
        // and the position does not seem to increase
        // and the player isn't manually paused...
        if (
            !bufferingDetected
            && currentPlayPos < (lastPlayPos + offset)
            && !player.paused
        ) {
            console.log("buffering")
            bufferingDetected = true
            submitError('buffering error', player.currentTime());
        }

        // if we were buffering but the player has advanced,
        // then there is no buffering
        if (
            bufferingDetected
            && currentPlayPos > (lastPlayPos + offset)
            && !player.paused
        ) {
            console.log("not buffering anymore")
            bufferingDetected = false
        }
        lastPlayPos = currentPlayPos
    }
}