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
                fetch("https://localhost:7079/api/Education/GetTrainersEducation?" + new URLSearchParams
                ({

                    email : EmailID,
					

    
                })).then(response => response.json())
				.then(data => {
					// Display education details in the page
					const educationDetailsElement = document.getElementById('edu_details');
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

                // .then((res) => console.log(res))
                async function GetEdu() 
				{
					let edu = document.getElementById("_edu").value;
					localStorage.setItem("_Edu_",edu);
					fetch("https://localhost:7079/api/Education/GetTrainersEducationByType?" + new URLSearchParams
                ({

                    email : EmailID,
					edu : edu,
					

    
                }))
				.then((response) => {
					if (response.status == 200)
					{
						// localStorage.setItem("emailid",email);
						// alert("Logged in Sucessfully");
						return response.json();
						
						
						
						//window.location.href = "../../TrainerMenu/TrainerMenu.html";
					}
					else
					{
						alert("Please check the credentails");
					}
				}).then(data => {
					console.log(data);
					console.log(data[0].skill); 
					const markup=`
					<!-- <div class="form-row"> -->
					<div class="container">
					<h2>Update your skills here</h2>
						<div class="form-group">
							<label for="comp_name">Education Type :</label>
							<input type="text"  value="${data[0].educationType}" name="name" id="edu__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Institute Name :</label>
							<input type="text" value="${data[0].instituteName}"name="name" id="inst__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Stream :</label>
							<input type="text" value="${data[0].stream}"name="name" id="str__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Start Year :</label>
							<input type="text" value="${data[0].startYear}"name="name" id="start__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Institute Name :</label>
							<input type="text" value="${data[0].endYear}"name="name" id="end__" required/>
						</div>
						<div class="form-group">
							<label for="comp_name">Institute Name :</label>
							<input type="text" value="${data[0].percentage}"name="name" id="per__" required/>
						</div>
						<button type="submit" onclick="updateEdu()">Update</button>
					</div>	
					<!-- </div> -->
				   
					`;
					document.querySelector('.container').insertAdjacentHTML("afterend",markup);
				})


					
				}  

				
				async function updateEdu() {
					let _Edu_ = localStorage.getItem("_Edu_");
					let edu_ = document.getElementById("edu__").value;
					let inst_ = document.getElementById("inst__").value;
					let str_ = document.getElementById("str__").value;
					let start_ = document.getElementById("start__").value;
					let end_ = document.getElementById("end__").value;
					let per_ = document.getElementById("per__").value;
					//let skill3 = document.getElementById("skill3").value
				
					// let val = EmailID.split('@');
					// UserID = val[0];
				    // console.log(skill_);
					// console.log(prof_);
					// console.log(Skill_1);
					fetch("https://localhost:7079/api/Education/UpdateTrainersEducation?" + new URLSearchParams
						({
							email: EmailID,
							educationType: _Edu_ ,
							
						}), {
							
						method: "PUT",
				
						body: JSON.stringify({
							emailid: "string",
							educationType: edu_,
							instituteName: inst_,
							stream : str_,
							startYear : start_,
							endYear : end_,
							percentage : per_,
							//skill_3: skill3
						}),
						headers: {
							"Content-type": "application/json; charset=UTF-8",
						}
					})
						.then((response) =>
						 
						console.log(response))
						window.location.href = "ViewEduDetails.html"
				
					alert("Data Updated")
				}				