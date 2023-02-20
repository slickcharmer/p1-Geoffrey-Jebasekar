//var UserID;
var useremail;
// var log1;
// function PassEmail(email) {
//     this.email = email;
//     this.Pass = function() 
//     {
//         return email;
        
//     }
// }
let EmailID = localStorage.getItem("emailid");
EmailID = EmailID.replace(/['‘’"“”]/g, '');
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
async function ValidateLogin() {
    const signinform = document.getElementById("login-form");

    signinform.addEventListener("submit", event => {    
        event.preventDefault(); });

    let email = document.getElementById("your_name").value;
    let pass = document.getElementById("your_pass").value;
    useremail = email;
    
    console.log(useremail);
    await fetch("https://localhost:7079/api/Login/ValidateTrainer?" + new URLSearchParams
    ({
        Email: email,
        Pass: pass
    }), {
        //mode: 'no-cors',
        method: "GET",

        headers: {
            "Content-type": "application/json; charset=UTF-8",
        }
    })

    .then((response) => {
        if (response.status == 200)
        {
            localStorage.setItem("emailid",email);
            alert("Logged in Sucessfully");
            const data = response.json();
            console.log(data);
            window.location.href = "../../TrainerMenu/TrainerMenu.html";
        }
        else
        {
            alert("Please check the credentails");
        }
    })
    
    // .then((response) => response.json())
    // .then(json => console.log(json))
}
async function addeducation() {

    

    const regform = document.getElementById("register-form");

    regform.addEventListener("submit", event => {
        event.preventDefault(); });

    let edu = document.getElementById("edu").value;
    let instname = document.getElementById("inst_name").value;
    let stream = document.getElementById("stream").value;
    let startyear = document.getElementById("start").value;
    let endyear = document.getElementById("end").value;
    let percentage = document.getElementById("percentage").value;
    // let pgper = document.getElementById("pgper").value;
    // let pgyear = document.getElementById("pgyear").value;
    //let email = log1.Pass();
   
    
    
    console.log(EmailID);
    await fetch("https://localhost:7079/api/Education/AddTrainerEducation",
        {
            method: "POST",

            body: JSON.stringify({
                emailid: EmailID,
                educationType: edu,
                instituteName: instname,
                stream: stream,
                startYear: startyear,
                endYear: endyear,
                percentage: percentage,
                
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        // .then((response) => response.json())
        // .then(json => console.log(json))

        .then((response) => {
            if (response.status == 200)
            {
                
                alert("Trainer Education added Sucessfully");
                const data = response.json();
                console.log(data);

                
                window.location.href = "../../TrainerMenu.html";
            }
            else
            {
                console.error('Error:', response.status);
            }
        })
}

async function addskill() {

    const skillform = document.getElementById("register-form");

    skillform.addEventListener("submit", event => {
        event.preventDefault(); });

    let skill = document.getElementById("skill").value;
    let prof = document.getElementById("prof").value;
    // let skill2 = document.getElementById("skill2").value;
    // let skill3 = document.getElementById("skill3").value;
    console.log(EmailID);
    await fetch("https://localhost:7079/api/Skills/AddTrainerSkills",
        {
            method: "POST",

            body: JSON.stringify({
                emailid: EmailID,
                skill: skill,
                profeciencyInSkill: prof,
                
            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        // .then((response) => response.json())
        // .then(json => console.log(json))
        .then((response) => {
            if (response.status == 200)
            {
                
                alert("Trainer skill added Sucessfully");
                const data = response.json();
                console.log(data);

                
                window.location.href = "../../TrainerMenu.html";
            }
            else
            {
                console.error('Error:', response.status);
            }
        })
}

async function addcompany() {

    const expform = document.getElementById("register-form");

    expform.addEventListener("submit", event => {
        event.preventDefault(); });

    let companyname = document.getElementById("comp_name").value;
    let title = document.getElementById("title").value;
    let experience = document.getElementById("experience").value;
    let location = document.getElementById("location").value;


    console.log(EmailID);
    await fetch("https://localhost:7079/api/Experience/AddTrainerExperience",
        {
            method: "POST",

            body: JSON.stringify({
                emailid: EmailID,
                companyName: companyname,
                title: title,
                experience: experience,
                location: location,

            }),

            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })

        // .then((response) => response.json())
        // .then(json => console.log(json))
        .then((response) => {
            if (response.status == 200)
            {
                
                alert("Trainer experience added Sucessfully");
                const data = response.json();
                console.log(data);

                
                window.location.href = "../../TrainerMenu.html";
            }
            else
            {
                console.error('Error:', response.status);
            }
        })


    }        

        function DeleteAccount() {

            // let skill = document.getElementById("skill").value;
            // localStorage.setItem("Skill",skill);
            // let Skill_1 = localStorage.getItem("Skill");

            // var companyName = prompt("Enter the company name");
            // var choice = confirm("Are you sure?");
            // let Skill_1 = localStorage.getItem("Skill");
            // let skill_ = document.getElementById("skill__").value
            // let prof_ = document.getElementById("profeciency").value
        
            // if(choice){
            // 	   let options = {
            // 		method: "DELETE"
            // 	}; 
            // 	https://localhost:7079/api/Skills/DeleteTrainerSkills?email=geffshelby%40gmail.com&skill=C

            // 	   fetch(`https://localhost:44329/Company/delete?company=${companyName.trim()}&email=${localStorage.getItem('LoginEmail')}`, options)
            // 	.then((response) => {
            // 		if (response.ok) {
            // 		   window.location.href = "DeleteSkillDetails.html";
            // 		}
        
            // 	});
            // }
            var choice = confirm("Are you sure?");
            console.log(EmailID);
            if(choice)
            {
            fetch("https://localhost:7079/api/Signup/DeleteAccount?" + new URLSearchParams
            ({
                email : EmailID,
                

            }),
            {
                method: "DELETE",
                
            }).then((response)=>{
                if (response.ok) {
                    alert("Account Deleted Successfully");
                               //window.location.href = "DeleteSkillDetails.html";
                            }
                
            })
        }
        else
        {
            window.location.href = "TrainerMenu.html";
        }
        // else
        // {
        //     window.location.href = "TrainerMenu.html";
        // }
           
        }
        
    async function ViewDetails() 
     {
        
        console.log(EmailID);
        window.location.href = "../ViewDetails/ViewDetails.html";
        await fetch("https://localhost:7079/api/Signup/GetTrainer?" + new URLSearchParams
        ({

            email : EmailID,
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('container');
            data.forEach(prof => {
                const educationElement = document.createElement('div');
                educationElement.classList.add('row');
                // <div class = "label">Welcome</div>;
                // <div class="value">${skill.emailid}</div>;
                educationElement.innerHTML = `
                    <div class="label">First Name:</div>
                    <div class="value">${prof.firstname}</div>
                    <div class="label">Last Name:</div>
                    <div class="value">${prof.lastname}</div>
                    <div class="label">Email:</div>
                    <div class="value">${prof.emailId}</div>
                    <div class="label">Phone Number:</div>
                    <div class="value">${prof.phoneno}</div>
                    <div class="label">Age:</div>
                    <div class="value">${prof.age}</div>
                    <div class="label">City:</div>
                    <div class="value">${prof.city}</div>
                    
                `;
                educationDetailsElement.appendChild(educationElement);
            });
        })
        .catch(error => {
            console.error(error);
            alert('An error occurred while loading education details.');
        });

        await fetch("https://localhost:7079/api/Education/GetTrainersEducation?" + new URLSearchParams
        ({

            email : EmailID,
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('details');
            data.forEach(edu => {
                const educationElement = document.createElement('div');
                educationElement.classList.add('row');
                // <div class = "label">Welcome</div>;
                // <div class="value">${skill.emailid}</div>;
                educationElement.innerHTML = `
                    <div class="label">Education type:</div>
                    <div class="value">${edu.educationType}</div>
                    <div class="label">Institute Name:</div>
                    <div class="value">${edu.instituteName}</div>
                    <div class="label">Stream:</div>
                    <div class="value">${edu.stream}</div>
                    <div class="label">Start Year:</div>
                    <div class="value">${edu.startYear}</div>
                    <div class="label">End Year:</div>
                    <div class="value">${edu.endYear}</div>
                    <div class="label">Percentage:</div>
                    <div class="value">${edu.percentage}</div>
                    
                `;
                educationDetailsElement.appendChild(educationElement);
            });
        })
        .catch(error => {
            console.error(error);
            alert('An error occurred while loading education details.');
        });

        
     }   

