import { Component, Input  } from '@angular/core';
import moment from "moment"

@Component({
  selector: 'app-comment',
  standalone: true,
  imports: [],
  templateUrl: './comment.component.html',
  styles: ``
})
export class CommentComponent {

  @Input() comment: any;

  dateConvert(datetime:any): string{
    return moment(datetime).format("MMMM DD, Y HH:mm:ss");
  }

  getClasses(comment:any){
    if(comment.children.length === 0){
        if(comment.parentId === null){
            return "d-flex mb-4"
        }else{
            return "d-flex mt-4"
        }
    }else{
        return "d-flex mt-4"
    }
}

}
