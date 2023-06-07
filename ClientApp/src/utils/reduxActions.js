export const asyncActionType = (type: any) => ({
    PENDING: `${type} - Pending`,
    SUCCESS: `${type} - Success`,
    ERROR: `${type} - Error`,
});
