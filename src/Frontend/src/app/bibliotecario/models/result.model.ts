export interface Result<T> {
    data:        T;
    errors:      string[];
    isSuccess:   boolean;
    message:     string;
    validations: Validations[];
}
export interface Validations {
}
