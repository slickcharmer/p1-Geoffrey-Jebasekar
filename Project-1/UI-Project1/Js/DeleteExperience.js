let EmailID = localStorage.getItem("emailid");
EmailID = EmailID.replace(/['‘’"“”]/g, '');

// var skill_1;
// var prof;
//Skill = Skill.replace(/['‘’"“”]/g, '');

           // function GetSkill() {
				
                // let email = document.getElementById("email").value;
				// console.log(email);
                // let id;
				// let skills;
				// let prof;
                // Make an API request to get education details
                fetch("https://localhost:7079/api/Experience/GetTrainersExperience?" + new URLSearchParams
                ({

                    email : EmailID,
					

    
                })).then(response => response.json())
				.then(data => {
					// Display education details in the page
					const educationDetailsElement = document.getElementById('exp_details');
					data.forEach(exp => {
						const educationElement = document.createElement('div');
						educationElement.classList.add('row');
						// <div class = "label">Welcome</div>;
						// <div class="value">${skill.emailid}</div>;
						educationElement.innerHTML = `
							<div class="label">Company Name:</div>
							<div class="value">${exp.companyName}</div>
							<div class="label">Title:</div>
							<div class="value">${exp.title}</div>
							<div class="label">Experience in Years:</div>
							<div class="value">${exp.experience}</div>
							<div class="label">Location:</div>
							<div class="value">${exp.location}</div>
							
							
						`;
						educationDetailsElement.appendChild(educationElement);
					});
				})
				.catch(error => {
					console.error(error);
					alert('An error occurred while loading experience details.');
				});



                function DeleteExp() {
                    let exp = document.getElementById("exp").value;
                    let title = document.getElementById("title").value;
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
                    console.log(exp);
                    fetch("https://localhost:7079/api/Experience/DeleteTrainersExperience?" + new URLSearchParams
                    ({
                        email : EmailID,
                        companyName : exp,
                        title : title,

                    }),
                    {
                        method: "DELETE",
                        
                    }).then((response)=>{
                        if (response.ok) {
                            		   window.location.href = "DeleteExperienceDetails.html";
                            		}
                        
                    })
                   
				}