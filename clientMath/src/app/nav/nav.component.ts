import {Component, OnInit, HostListener} from '@angular/core';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {UserService} from '../_services/user.service';
import {SharedService} from '../_services/shared.service';
import {TopicService} from "../_services/topic.service";
import {TopicModel} from "../_models/q/topic";
import {QuestionModel} from "../_models/q/question";
import {QuestionService} from "../_services/question.service";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  isLoggedIn: any;
  fullName: string = '';

  isBurgerMenuOpen: boolean = false;
  isProfileButtonsVisible: boolean = true;

  pickedTopic: string = '';

  topics: TopicModel[] = [new TopicModel('Global Quiz')];
  // topics: TopicModel[] = [];

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private userService: UserService,
    private sharedService: SharedService,
    private topicService: TopicService,
    private questionService: QuestionService
  ) {
  }

  ngOnInit(): void {
    this.getTopics();

    this.userService.fullName$.subscribe(fullName => {
      this.fullName = fullName;
    });


    this.sharedService.fullName$.subscribe(fullName => {
      this.fullName = fullName;
    });

    this.sharedService.isLoggedIn$.subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn;
    });

    this.userService.isLoggedIn$.subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn;
    });

    this.sharedService.pickedTopic$.subscribe(topic => {
      this.pickedTopic = topic;
    });
  }

  @HostListener('window:resize', ['$event'])
  onWindowResize(event: Event) {
    this.updateButtonVisibility();
  }

  toggleBurgerMenu() {
    this.isBurgerMenuOpen = !this.isBurgerMenuOpen;
    this.updateButtonVisibility();
  }

  private updateButtonVisibility() {
    const windowWidth = window.innerWidth;
    if (windowWidth <= 768) {
      this.isProfileButtonsVisible = !this.isBurgerMenuOpen;
    } else {
      this.isProfileButtonsVisible = true;
    }
  }

  SignOut() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
    this.isLoggedIn = null;
    console.log('logged out');
    this.userService.setLoggedIn(false);
    this.toastr.success('Logout successful', 'Logout');
    this.fullName = 'Guest';
  }

  getValue(topic: string) {
    this.sharedService.updateData(topic);
  }

  showMe() {
    console.log(this.topics);
  }

  getTopics() {
    this.topicService.getTopics().subscribe(
      (topics: TopicModel[]) => {
        for (const topic of topics) {
          if(topic.text == "Math") continue;
          this.topics.push(topic);
        }
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

}
