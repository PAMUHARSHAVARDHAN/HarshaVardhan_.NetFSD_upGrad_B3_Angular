//  Variable Declaration 
let userName: string = "Harsha";
let age: number = 22;
const email: string = "harsha@gmail.com";
let isSubscribed: boolean = true;


//Type Inference 
let city = "sircilla";       
let pincode  = 505301;          


age = age + 1;  

// Template Literals
const userProfile: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;

// Eligibility check (age > 18 AND subscribed)
let isEligible: boolean = age > 18 && isSubscribed;


console.log("User Name:", userName);
console.log("Age after increment:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);

console.log("City (Inferred):", city);
console.log("Pincode (Inferred):", pincode  );

console.log("User Profile Message:");
console.log(userProfile);

console.log("Eligible for Premium Plan:", isEligible);