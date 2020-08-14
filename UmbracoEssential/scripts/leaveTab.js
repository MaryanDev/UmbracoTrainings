class LeaveTab {
    constructor(msg) {
        this.message = msg;
        this.init();
    }

    init() {
        this.listeners();
    }

    listeners() {
        $(window).on("unload", function () {
            alert(this.message);
        }.bind(this));
    }
}