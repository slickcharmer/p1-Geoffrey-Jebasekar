//var UserID;

function signUpfunction() {
    //let userId = document.getElementById("userid").value; 
    let email = document.getElementById("email").value;
    let password = document.getElementById("pass").value;
    let fname = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;
    let age = document.getElementById("age").value;
    //let gender = document.getElementById("gender").value;
    let phonenumber = document.getElementById("phone_no").value;
    let city = document.getElementById("city").value;

    if(email == null || email =="")
    {
        alert("Email ID cannot be empty");
    }
    if(password == null || password =="")
    {
        alert("Password cannot be empty");
    }
    if(fname == null || fname == "")
    {
        alert("Firstname cannot be empty");
    }
    if(lname == null || lname == "")
    {
        alert("Lastname cannot be empty");
    }
    if(age == null || age == "")
    {
        alert("Age cannot be empty");
    }
    // if(gender == null || gender == "")
    // {
    //     alert("Gender cannot be empty");
    // }
    if(phonenumber == null || phonenumber == "")
    {
        alert("Phonenumber cannot be empty");
    }
    if(city == null || city == "")
    {
        alert("City cannot be empty");
    }

    addpersonal();
    // addeducation();
    // addskill();
    // addcompany();
}


async function addpersonal() {

    const signinform = document.getElementById("register-form");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    //let userId = document.getElementById("userid").value; 
    let email = document.getElementById("email").value;
    let password = document.getElementById("pass").value;
    let fname = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;
    let age = document.getElementById("age").value;
    //let gender = document.getElementById("gender").value;
    let phonenumber = document.getElementById("phone_no").value;
    let city = document.getElementById("city").value;

    // let val = email.split('@');
    // UserID = val[0];

    console.log(email);

    await fetch("https://localhost:7079/api/Signup/AddTrainer",
        {
            method: "POST",
            
            body: JSON.stringify({
                //userid: UserID,
                firstname: fname,
                lastname: lname,
                emailId: email,
                password: password,
                phoneno: phonenumber,
                age: age,
                //gender: gender,
                city: city,
            }),

            headers: {
                'Accept': 'application/json',
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        // .then((response) => response.json())
        // .then(json => console.log(json))
        // .catch(error => console.log(error))

        .then((response) => {
            if (response.status == 200)
            {
                alert("Signed up Sucessfully");
                const data = response.json();
                console.log(data);

                
                window.location.href = "../../Login/colorlib-regform-7/index.html";
            }
            else
            {
                console.error('Error:', response.status);
            }
        })

}

async function addeducation() {

    const regform = document.getElementById("register-form");

    regform.addEventListener("submit", event => {
        event.preventDefault(); });

    let edu = document.getElementById("edu").value;
    let instname = document.getElementById("inst_name").value;
    let stream = document.getElementById("stream").value;
    let ugyear = document.getElementById("ugyear").value;
    let pclgname = document.getElementById("pclgname").value;
    let pgstream = document.getElementById("pgstream").value;
    // let pgper = document.getElementById("pgper").value;
    // let pgyear = document.getElementById("pgyear").value;

    await fetch("https://localhost:7079/api/Education/AddTrainerEducation?",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                ug_collage: uclgname,
                ug_stream: ugstream,
                ug_percentage: ugper,
                ug_year: ugyear,
                pg_collage: pclgname,
                pg_stream: pgstream,
                pg_percentage: pgper,
                pg_year: pgyear
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}

async function addskill() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    let skill1 = document.getElementById("skill1").value;
    let skill2 = document.getElementById("skill2").value;
    let skill3 = document.getElementById("skill3").value;

    await fetch("https://localhost:7234/Api/TrainerSignup/AddSkill",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                skill_1: skill1,
                skill_2: skill2,
                skill_3: skill3
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}

async function addcompany() {

    const signinform = document.getElementById("signupform");

    signinform.addEventListener("submit", event => {
        event.preventDefault(); });

    let companyname = document.getElementById("companyname").value;
    let field = document.getElementById("field").value;
    let experience = document.getElementById("experience").value;

    await fetch("https://localhost:7234/Api/TrainerSignup/AddCompany",
        {
            method: "POST",

            body: JSON.stringify({
                userid: UserID,
                companyname: companyname,
                field: field,
                experience: experience
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        .then((response) => response.json())
        .then(json => console.log(json))
}
