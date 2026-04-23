//  Function with Required Parameter
function getWelcomeMessage(name: string): string {
    return `Welcome, ${name}!`;
}

//  Optional Parameter
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `Hello ${name}, you are ${age} years old.`;
    }
    return `Hello ${name}`;
}

// Default Parameter
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed
        ? `${name}, you are subscribed.`
        : `${name}, you are not subscribed.`;
}

// Function Returning Boolean
function isEligibleForPremium(age: number): boolean {
    return age > 18;
}

// Arrow Function
const getAlertMessage = (message: string): string => {
    return `Alert: ${message}`;
};

// Lexical 
const notificationService = {
    appName: "NotifyApp",

    sendNotification: (user: string): string => {
        return `Hello ${user}, welcome to ${notificationService.appName}`;
    }
};


console.log(getWelcomeMessage("Harsha"));

console.log(getUserInfo("Harsha"));
console.log(getUserInfo("Harsha", 22));

console.log(getSubscriptionStatus("Harsha"));
console.log(getSubscriptionStatus("Harsha", true));

console.log("Eligible for Premium:", isEligibleForPremium(22));

console.log(getAlertMessage("Your account has been updated"));

console.log(notificationService.sendNotification("Harsha"));