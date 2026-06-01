
import tkinter as tk
import random
import math

WIDTH = 400
HEIGHT = 600

# formation movement
enemies_dx = 3
enemy_drop = 20

# ---------------- WAVES ----------------
wave = 1
wave_cleared = False
transitioning_wave = False

boss_warning = False
boss_timer = 0

boss = None
boss_hp = 50
boss_active = False
boss_warning = False

player_alive = True
respawn_timer = 0
invincible_timer = 0

root = tk.Tk()
root.title("Galaga - Final")

canvas = tk.Canvas(root, width=WIDTH, height=HEIGHT)
canvas.pack()

# ---------------- BACKGROUND ----------------
bg_img = tk.PhotoImage(file="galaxy.png")
bg = canvas.create_image(0, 0, image=bg_img, anchor="nw")

# ---------------- GAME STATE ----------------
bullets = []
enemies = []
enemy_bullets = []
explosions = []

score = 0
lives = 3
game_over = False

boss = None
boss_active = False
boss_warning = False
boss_hp = 50

player_alive = True
invincible_timer = 0
respawn_timer = 0
enemies_dx = 3

moving_left = False
moving_right = False

# ---------------- EXPLOSION ----------------
def create_explosion(x, y):
    parts = []

    for _ in range(10):  # number of particles
        p = canvas.create_rectangle(x, y, x+3, y+3, fill="orange", outline="")
        
        parts.append({
            "id": p,
            "dx": random.uniform(-3, 3),
            "dy": random.uniform(-3, 3),
            "life": 15
        })

    explosions.append(parts)

def create_player_explosion(x, y):
    parts = []

    for _ in range(25):  # mas marami = mas malakas explosion
        p = canvas.create_rectangle(
            x, y, x+4, y+4,
            fill=random.choice(["yellow", "orange", "red"]),
            outline=""
        )

        parts.append({
            "id": p,
            "dx": random.uniform(-5, 5),
            "dy": random.uniform(-5, 5),
            "life": 25
        })

    explosions.append(parts)

def spawn_boss():
    global boss, boss_active, boss_hp

    boss_active = True
    boss_hp = 50

    boss ={
        "id": create_boss(120, 50),
        "t": 0
    }

# ---------------- UI ----------------
score_text = canvas.create_text(10, 10, anchor="nw", fill="white", font=("Arial", 12))
lives_text = canvas.create_text(300, 10, anchor="nw", fill="white", font=("Arial", 12))

# ---------------- ENEMIES ----------------
def create_enemy(x, y, enemy_type=1):
    size = 4
    pixels = []

    # 👾 TYPE 1 (purple bug)
    if enemy_type == 1:
        shape = [
            [0,1,0,1,0],
            [1,2,2,2,1],
            [1,2,3,2,1],
            [0,1,2,1,0],
        ]
        colors = {1:"#3a86ff", 2:"#ff00ff", 3:"white"}

    # 👾 TYPE 2 (yellow-red)
    elif enemy_type == 2:
        shape = [
            [0,2,0,2,0],
            [2,3,3,3,2],
            [2,3,1,3,2],
            [0,2,2,2,0],
        ]
        colors = {1:"yellow", 2:"red", 3:"orange"}

    # 👾 TYPE 3 (green alien)
    else:
        shape = [
            [0,1,1,1,0],
            [1,2,2,2,1],
            [1,2,3,2,1],
            [0,1,1,1,0],
        ]
        colors = {1:"green", 2:"lime", 3:"red"}

    for r in range(len(shape)):
        for c in range(len(shape[r])):
            val = shape[r][c]
            if val != 0:
                x1 = x + c * size
                y1 = y + r * size
                x2 = x1 + size
                y2 = y1 + size

                pixel = canvas.create_rectangle(
                    x1, y1, x2, y2,
                    fill=colors[val],
                    outline="",
                    tags="enemy"
                )
                pixels.append(pixel)

    return pixels

# ---------------- BOSS ----------------
def create_boss(x, y):
    pixels = []

    shape = [
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 5, 5, 5, 1, 1, 2, 1, 1, 5, 5, 5, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 5, 0, 5, 1, 1, 2, 1, 1, 5, 0, 5, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 2, 2, 4, 4, 2, 4, 4, 2, 2, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 2, 2, 0, 2, 2, 2, 4, 4, 4, 4, 4, 2, 2, 2, 0, 2, 2, 0, 0, 0] ,
        [0, 0, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4, 2, 2, 2, 2, 2, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 2, 2, 0, 4, 4, 4, 4, 4, 0, 2, 2, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 2, 2, 0, 0, 2, 0, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 2, 2, 0, 0, 2, 0, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
        [0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] ,
    ]

    colors = {
        0: "transparent",
        1: "red",
        2: "blue",
        3: "green",
        4: "yellow",
        5: "black"
    }

    size = 6  # adjust mo kung gaano kalaki

    for row_idx, row in enumerate(shape):
        for col_idx, val in enumerate(row):
            if val != 0:
                px = x + col_idx * size
                py = y + row_idx * size

                rect = canvas.create_rectangle(
                    px, py,
                    px + size, py + size,
                    fill=colors.get(val, "white"),
                    outline="",
                    tags="boss"
                )
                pixels.append(rect)

    return pixels

# ---------------- PLAYER ----------------
def create_player():
    size = 4

    shape = [
        [0,0,0,0,0,0,0,3,0,0,0,0,0],
        [0,0,0,0,0,0,0,3,0,0,0,0,0,0],
        [0,0,0,0,0,0,0,2,0,0,0,0,0,0],
        [0,0,0,0,0,0,2,2,2,0,0,0,0,0,0],
        [0,0,0,0,0,0,2,2,2,0,0,0,0,0,0],
        [0,0,0,3,0,0,2,2,2,0,0,3,0,0,0],
        [0,0,0,3,0,0,2,2,2,0,0,3,0,0,0],
        [0,0,0,2,0,2,2,2,2,2,0,2,0,0,0],
        [3,0,0,2,4,2,2,3,2,2,4,2,0,0,3],
        [3,0,0,4,2,2,3,3,3,2,2,4,0,0,3],
        [2,0,2,2,2,2,3,2,3,2,2,2,0,0,2],
        [2,2,2,2,2,2,2,2,2,2,2,2,2,0,2],
        [2,2,2,2,2,3,2,2,2,3,2,2,2,2,2],
        [2,2,2,0,3,3,2,2,2,3,3,0,2,2,2],
        [2,0,0,0,3,3,0,2,0,3,3,0,0,2,2],
        [2,0,0,0,0,0,0,2,0,0,0,0,0,0,2],
    ]

    colors = {1:"black",2:"white",3:"red",4:"blue"}

    start_x = WIDTH//2 - (len(shape[0]) * size)//2
    start_y = HEIGHT - 70

    for r in range(len(shape)):
        for c in range(len(shape[r])):
            val = shape[r][c]
            if val != 0:
                x1 = start_x + c * size
                y1 = start_y + r * size
                x2 = x1 + size
                y2 = y1 + size
                canvas.create_rectangle(
                    x1, y1, x2, y2,
                    fill=colors[val],
                    outline="",
                    tags="player"
                )

create_player()

# ---------------- CONTROLS ----------------
def key_press(e):
    global moving_left, moving_right
    if e.keysym == "Left":
        moving_left = True
    elif e.keysym == "Right":
        moving_right = True

def key_release(e):
    global moving_left, moving_right
    if e.keysym == "Left":
        moving_left = False
    elif e.keysym == "Right":
        moving_right = False

def shoot(e):
    if game_over:
        return

    bbox = canvas.bbox("player")

    if not bbox:
        return

    x1, y1, x2, y2 = bbox

    bullet = canvas.create_rectangle(
        (x1+x2)//2,
        y1-10,
        (x1+x2)//2+3,
        y1,
        fill="red"
    )

    bullets.append(bullet)

# ---------------- ENEMY FORMATION ----------------
def create_enemy_formation():

    global enemies_dx

    enemies.clear()
    canvas.delete("enemy")

    enemies_dx = 2 + wave  # increase speed each wave

    rows = 4
    cols = 8

    # WAVE SETTINGS
    if wave == 1:
        spacing_x = 40
        spacing_y = 40

    elif wave == 2:
        spacing_x = 35
        spacing_y = 35

    else:  # wave 3
        spacing_x = 30
        spacing_y = 30
        rows = 5

    for r in range(rows):
        for c in range(cols):

            x = 40 + c * spacing_x
            y = 50 + r * spacing_y

            enemy_type = random.randint(1, 3)

            enemy_pixels = create_enemy(x, y, enemy_type)

            enemies.append({
                "id": enemy_pixels,
                "state": "idle",
                "dx": 0,
                "dy": 0,
                "home_x": x,
                "home_y": y,

                # AGGRESSION VALUES
                "aggression": wave
            })


# ---------------- COLLISION ----------------
def is_collision(obj, target):
    obox = canvas.bbox(obj)
    if not obox:
        return False

    if isinstance(target, list):
        for p in target:
            tbox = canvas.bbox(p)
            if tbox and not (obox[2] < tbox[0] or obox[0] > tbox[2] or obox[3] < tbox[1] or obox[1] > tbox[3]):
                return True
        return False
    else:
        tbox = canvas.bbox(target)
        if not tbox:
            return False
        return not (obox[2] < tbox[0] or obox[0] > tbox[2] or obox[3] < tbox[1] or obox[1] > tbox[3])
    
    
def game_loop():
    global boss, boss_hp, boss_active
    global boss_warning, boss_timer
    global score, lives, game_over
    global player_alive, respawn_timer, invincible_timer
    global enemies_dx
    global wave
    global transitioning_wave


    if game_over:
        root.after(30, game_loop)
        return

    # ---------------- PLAYER MOVEMENT ----------------
    if invincible_timer > 0:
        invincible_timer -= 1
        if invincible_timer % 5 < 2:
            canvas.itemconfig("player", state="hidden")
        else:
            canvas.itemconfig("player", state="normal")

    else:
        canvas.itemconfig("player", state="normal")
            
    bbox = canvas.bbox("player")
    if bbox:
        x1, y1, x2, y2 = bbox

        if moving_left and x1 > 0:
            canvas.move("player", -8, 0)

        if moving_right and x2 < WIDTH:
            canvas.move("player", 8, 0)
    

    if len(enemies) == 0 and not transitioning_wave and not boss_active:

        transitioning_wave = True
        
        for eb in enemy_bullets:
            canvas.delete(eb)

        enemy_bullets.clear()

        if wave < 3:

            wave += 1

            canvas.create_text(
                WIDTH//2, HEIGHT//2,
                text=f"WAVE {wave}",
                fill="white",
                font=("Arial", 20, "bold"),
                tags="wave_text"
            )

            def next_wave():
                global transitioning_wave

                canvas.delete("wave_text")
                create_enemy_formation()
                transitioning_wave = False

            root.after(2000, next_wave)

        else:

            canvas.create_text(
                WIDTH//2, HEIGHT//2,
                text="FINAL WAVE CLEARED!",
                fill="white",
                font=("Arial", 20, "bold"),
                tags="wave_text"
            )

            def start_boss():
                global boss_warning
                global transitioning_wave

                canvas.delete("warning")

                boss_warning = True
                spawn_boss()

                transitioning_wave = False

            root.after(3000, start_boss)

    # ---------------- PLAYER BULLETS ----------------
    for b in bullets[:]:
        coords = canvas.coords(b)
        if not coords:
            canvas.delete(b)
            bullets.remove(b)
            continue
        canvas.move(b, 0, -10)
        if canvas.coords(b)[1] < 0:
            canvas.delete(b)
            bullets.remove(b)

    move_down = False

    for e in enemies:
        if e["id"]:
            bbox = canvas.bbox(e["id"][0])

            if bbox:
                if bbox[2] >= WIDTH - 10 and enemies_dx > 0:
                    move_down = True
                    break
                elif bbox[0] <= 10 and enemies_dx < 0:
                    move_down = True
                    break

    if move_down:
        enemies_dx *= -1

        for e in enemies:
            for p in e["id"]:
                canvas.move(p, 0, enemy_drop)

    else:
        for e in enemies:
            if e["state"] == "idle":
                for p in e["id"]:
                    canvas.move(p, enemies_dx, 0)

    # ---------------- ENEMY SHOOTING ----------------
    shooting_rate = {
        1: 40,  # wave 1 - 1 in 40 chance
        2: 20,  # wave 2 - 1 in 20 chance  
        3: 20   # wave 3 - 1 in 20 chance
    }
    if random.randint(1, shooting_rate.get(wave, 10)) == 1 and enemies:
        idle = [e for e in enemies if e["state"] == "idle" and e["id"]]
        if idle:
            e = random.choice(idle)
            bbox = canvas.bbox(e["id"][0])
            if bbox:
                ex1, ey1, ex2, ey2 = bbox
                eb = canvas.create_rectangle((ex1+ex2)//2, ey2, (ex1+ex2)//2+3, ey2+10, fill="yellow")
                enemy_bullets.append(eb)

    # ---------------- RANDOM DIVE (TARGET PLAYER) ----------------

    dive_chance ={
        1: 20,  # wave 1 - 1 in 20 chance
        2: 15,  # wave 2 - 1 in 15 chance
        3: 10   # wave 3 - 1 in 10 chance
    }
    if random.randint(1, dive_chance.get(wave, 5)) == 1 and enemies:
        idle = [e for e in enemies if e["state"] == "idle" and e["id"]]
        if idle:
            d = random.choice(idle)
            bbox = canvas.bbox("player")
            if not bbox:
                pass  # player not present; skip dive
            else:
                px1, py1, px2, py2 = bbox
                player_x = (px1 + px2) // 2
                player_y = (py1 + py2) // 2

                enemy_bbox = canvas.bbox(d["id"][0])
                if enemy_bbox:
                    ex, ey = enemy_bbox[0], enemy_bbox[1]
                    dx = player_x - ex
                    dy = player_y - ey
                    dist = max((dx**2 + dy**2) ** 0.5, 1)

                    speed = 4 + wave * 2

                    d["vx"] = dx / dist * speed
                    d["vy"] = dy / dist * speed
                    d["t"] = 0
                    d["amplitude"] = random.randint(20, 50)
                    d["frequency"] = 0.1
                    d["state"] = "diving"

    # ---------------- BOSS MOVEMENT / ACTIONS ----------------
    if boss_active and boss:
        boss["t"] += 1
        dx = math.sin(boss["t"] * 0.1) * 6
        for p in boss["id"]:
            canvas.move(p, dx, 0)

        # example boss shot (guarded)
        if random.randint(1, 5) == 1:
            boss_bbox = canvas.bbox("boss")
            if boss_bbox:
                bx = (boss_bbox[0] + boss_bbox[2]) // 2
                y2 = boss_bbox[3]
                for offset in [-40, -20, 0, 20, 40]:  # multiple shots in a spread
                    boss_bullet = canvas.create_rectangle(
                        bx + offset,
                        y2,
                        bx + offset + 6,
                        y2 + 15,
                        fill="cyan"
                    )
                    enemy_bullets.append(boss_bullet)

    # ---------------- ENEMY BULLETS ----------------
    for eb in enemy_bullets[:]:
        canvas.move(eb, 0, 6)
        coords = canvas.coords(eb)
        if not coords or coords[3] > HEIGHT:
            canvas.delete(eb)
            if eb in enemy_bullets:
                enemy_bullets.remove(eb)
            continue

        if is_collision(eb, "player") and player_alive and invincible_timer <= 0:
            canvas.delete(eb)
            if eb in enemy_bullets:
                enemy_bullets.remove(eb)
            lives -= 1
            player_alive = False

            bbox = canvas.bbox("player")
            if bbox:
                x1, y1, x2, y2 = bbox
                px = (x1 + x2) // 2
                py = (y1 + y2) // 2
                create_player_explosion(px, py)

            canvas.delete("player")
            respawn_timer = 60

    # handle respawn timer once per frame (not per bullet)
    if not player_alive:
        respawn_timer -= 1

        if respawn_timer <= 0 and lives > 0:

            if not canvas.bbox("player"):
                create_player()
                
            player_alive = True
            invincible_timer = 60

    # ---------------- DIVING ENEMIES ----------------
    for e in enemies[:]:
        if e["state"] == "diving":
            if not e.get("id"):
                e["state"] = "returning"
                continue

            e["t"] += 1
            dx = e.get("vx", 0)
            dy = e.get("vy", 0)
            curve = e.get("amplitude", 0) * 0.05 * math.sin(e["t"] * e.get("frequency", 0.1))
            dx += curve

            for p in e["id"]:
                canvas.move(p, dx, dy)

            ebbox = canvas.bbox(e["id"][0])
            if ebbox and ebbox[3] > HEIGHT:
                e["state"] = "returning"
            elif is_collision(e["id"][0], "player") and invincible_timer <= 0:
                for p in e["id"]:
                    canvas.delete(p)
                if e in enemies:
                    enemies.remove(e)
                lives -= 1

    # ---------------- RETURNING ENEMIES ----------------
    for e in enemies:
        if e["state"] == "returning":
            if not e.get("id"):
                continue
            bbox = canvas.bbox(e["id"][0])
            if not bbox:
                continue
            x, y = bbox[0], bbox[1]
            dx = (e["home_x"] - x) * 0.1
            dy = (e["home_y"] - y) * 0.1
            for p in e["id"]:
                canvas.move(p, dx, dy)
            if abs(x - e["home_x"]) < 5 and abs(y - e["home_y"]) < 5:
                e["state"] = "idle"
                e["dx"] = 0
                e["dy"] = 0

    # ---------------- BULLET VS ENEMY ----------------
    for b in bullets[:]:
        for e in enemies[:]:
            if is_collision(b, e["id"]):
                bbox = canvas.bbox(e["id"][0])
                if bbox:
                    x, y = bbox[0], bbox[1]
                    create_explosion(x, y)
                for p in e["id"]:
                    canvas.delete(p)
                if e in enemies:
                    enemies.remove(e)
                if b in bullets:
                    canvas.delete(b)
                    bullets.remove(b)
                score += 10
                break

    # ---------------- BULLET VS BOSS ----------------
    if boss_active and boss and boss.get("id"):
        for b in bullets[:]:
            if not boss or not boss.get("id"):
                continue

            if is_collision(b, boss["id"]):

                canvas.delete(b)
                if b in bullets:
                    bullets.remove(b)


                boss_hp -= 1

                if boss_hp <= 0:

                    if boss and boss.get("id"):
                        bbox = canvas.bbox(boss["id"][0])
                        if bbox:
                            cx = (bbox[0] + bbox[2]) // 2
                            cy = (bbox[1] + bbox[3]) // 2
                            create_explosion(cx, cy)

                    try:
                        canvas.delete("boss")
                    except Exception:
                        if boss and boss.get("id"):
                            for p in boss["id"]:
                                try:
                                    canvas.delete(p)
                                except Exception:
                                    pass

                    boss_active = False
                    boss = None

                    canvas.delete("warning")
                    canvas.delete("wave_text")

                    canvas.create_text(
                        WIDTH//2, HEIGHT//2,
                        text="VICTORY!",
                        fill="green",
                        font=("Arial", 24, "bold"),
                        tags="victory"
                    )

                    canvas.create_text(
                        WIDTH//2, HEIGHT//2 + 40,
                        text=f"Final Score: {score}",
                        fill="white",
                        font=("Arial", 16),
                        tags="victory"
                    )

                    game_over = True
                    score += 100
                    break
                    



    # ---------------- EXPLOSIONS ----------------
    for exp in explosions[:]:
        for part in exp[:]:
            canvas.move(part["id"], part["dx"], part["dy"])
            part["life"] -= 1
            if part["life"] <= 0:
                canvas.delete(part["id"])
                exp.remove(part)
        if not exp:
            explosions.remove(exp)

    # ---------------- UI ----------------
    canvas.itemconfig(score_text, text=f"Score: {score}")
    canvas.itemconfig(lives_text, text=f"Lives: {lives}")

    canvas.delete("warning")
    if boss_warning:
        canvas.create_text(
            WIDTH//2, HEIGHT//2 - 50,
            text="⚠ WARNING! ang kupal ay padating na ⚠",
            fill="red",
            font=("Arial", 14, "bold"),
            tags="warning"
        )

    canvas.delete("boss_hp")
    if boss_active:
        canvas.create_text(150, 30, text=f"Boss HP: {boss_hp}", fill="white", font=("Arial", 12), tags="boss_hp")

    if lives <= 0 and not game_over:
        game_over = True
        bbox = canvas.bbox("player")
        if bbox:
            x1, y1, x2, y2 = bbox
            px = (x1 + x2) // 2
            py = (y1 + y2) // 2
            create_player_explosion(px, py)
        canvas.delete("player")
        canvas.create_text(WIDTH//2, HEIGHT//2, text="GAME OVER", fill="red", font=("Arial", 24))

    root.after(30, game_loop)


# ---------------- RESTART ----------------
def restart(e):
    global bullets, enemies, enemy_bullets, score, lives, game_over
    global boss, boss_active, boss_warning, boss_hp
    global player_alive, invincible_timer, respawn_timer
    global enemies_dx
    global explosions
    global moving_left, moving_right
    global wave, wave_cleared

    if not game_over:
        return

    canvas.delete("player")
    canvas.delete("boss")
    canvas.delete("bullet")
    canvas.delete("enemy")
    canvas.delete("enemy_bullet")
    canvas.delete("explosion")
    canvas.delete("warning")
    canvas.delete("victory")
    canvas.delete("boss_hp")

    canvas.create_image(0, 0, image=bg_img, anchor="nw")

    bullets.clear()
    enemies.clear()
    enemy_bullets.clear()
    explosions.clear()

    score = 0
    lives = 3
    wave = 1
    game_over = False

    boss = None
    boss_active = False
    boss_warning = False
    boss_hp = 50

    player_alive = True
    invincible_timer = 0
    respawn_timer = 0

    enemies_dx = 3

    moving_left = False
    moving_right = False

    global score_text, lives_text
    score_text = canvas.create_text(10, 10, anchor="nw", fill="white")
    lives_text = canvas.create_text(300, 10, anchor="nw", fill="white")

    if canvas.bbox("player"):
        canvas.delete("player")

    create_player()
    create_enemy_formation()


# ---------------- START ----------------
root.bind("<KeyPress>", key_press)
root.bind("<KeyRelease>", key_release)
root.bind("<space>", shoot)
root.bind("<r>", restart)

create_enemy_formation()
game_loop()
root.mainloop()