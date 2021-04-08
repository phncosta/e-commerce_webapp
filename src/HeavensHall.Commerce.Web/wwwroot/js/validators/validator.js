
class Validator {
    constructor(field) {
        this.field = field;
    }

    notFilled() {
        return this.field == "" || this.field == null;
    }
}