let EmailID = localStorage.getItem("emailid");
EmailID = EmailID.replace(/['‘’"“”]/g, '');
 console.log(EmailID);
        //window.location.href = "../ViewDetails/ViewDetails.html";
        fetch("https://localhost:7079/api/Signup/GetTrainer?" + new URLSearchParams
        ({

            email : EmailID,
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('details');
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

        fetch("https://localhost:7079/api/Education/GetTrainersEducation?" + new URLSearchParams
        ({

            email : EmailID,
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('details1');
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

        fetch("https://localhost:7079/api/Experience/GetTrainersExperience?" + new URLSearchParams
        ({

            email : EmailID,
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('details2');
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
            alert('An error occurred while loading education details.');
        });

        fetch("https://localhost:7079/api/Skills/GetTrainersSkills?" + new URLSearchParams
        ({

            email : EmailID,
            


        })).then(response => response.json())
        .then(data => {
            // Display education details in the page
            const educationDetailsElement = document.getElementById('details3');
            data.forEach(skill => {
                const educationElement = document.createElement('div');
                educationElement.classList.add('row');
                // <div class = "label">Welcome</div>;
                // <div class="value">${skill.emailid}</div>;
                educationElement.innerHTML = `
                    <div class="label">Skill name:</div>
                    <div class="value">${skill.skill}</div>
                    <div class="label">Profeciency in skill:</div>
                    <div class="value">${skill.profeciencyInSkill}</div>
                    
                `;
                educationDetailsElement.appendChild(educationElement);
            });
        })
        .catch(error => {
            console.error(error);
            alert('An error occurred while loading education details.');
        });