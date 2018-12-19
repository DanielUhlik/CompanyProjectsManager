import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Project } from "../../Models/models";
import axios from 'axios';

@Component({

})
export default class HomeComponent extends Vue {

    projectModel: Project = new Project();
    allProjects: Array<Project> = new Array<Project>();
    isEditMode: Boolean = false;

    mounted() {
        this.reloadData();
    }

    reloadData() {
        axios.get<Array<Project>>("/api/Projects").then(results => {
            this.allProjects = results.data;
        });
    }

    createModal() {
        this.isEditMode = false;
        this.projectModel = new Project();
    }

    editModal(id: string) {
        this.isEditMode = true;
        this.projectModel = this.allProjects.filter(p => p.id == id)[0];
    }

    create() {
        axios.post("/api/projects/create", this.projectModel).then(results => {
            this.allProjects.push(this.projectModel);
            this.projectModel.id = "prj" + this.allProjects.length
            this.projectModel = new Project();
            this.closeModal('edit-create-dialog-close');
        });
    }

    edit() {
        axios.put("/api/projects/edit", this.projectModel).then(results => {
            this.allProjects.filter(p => p.id == this.projectModel.id)[0] = this.projectModel;
            this.projectModel = new Project();
            this.closeModal('edit-create-dialog-close');
        });
    }

    deleteProject(index: number) {
        this.projectModel = this.allProjects[index]
    }

    confirmDelete() {
        console.log("delete")
        axios.delete("api/projects/delete/" + this.projectModel.id).then(results => {
            this.allProjects = this.allProjects.filter(item => item !== this.projectModel);
            this.closeModal('delete-dialog-close');
        });
    }

    closeModal(id: string) {
        let element = document.getElementById(id);
        if (element != null)
            element.click();
    }
}
