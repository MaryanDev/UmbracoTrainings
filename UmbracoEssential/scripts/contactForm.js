
class ContactForm {
    init () {
        this.listeners();
    }

    listeners() {
        $(document).on("click", ".contact-submit", (e) => {
            e.preventDefault();
            const form = $("#contact-form");
            form.submit();
        });
    }

    showResult() {
        $("#form-outer").hide("slow");
        $("#form-result").show("slow");
    }
}

const contactForm = new ContactForm();